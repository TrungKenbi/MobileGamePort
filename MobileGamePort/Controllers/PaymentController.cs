using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileGamePort.Data;
using MobileGamePort.Models;
using MoMo;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGamePort.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context, UserManager<User> userManager) : base(userManager)
        {
            _context = context;
        }
        // GET
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"];
            }
            ViewData["user"] = this.GetCurrentUser();
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ScratchCard([Bind("Telco,Amount,Serial,Code,Money")] ScratchCard scratchCard)
        {
            if (ModelState.IsValid)
            {
                scratchCard.RequestId = "MBGP_" + System.Guid.NewGuid().ToString();
                scratchCard.User = this.GetCurrentUser();
                scratchCard.Status = 99;
                scratchCard.Money = scratchCard.Amount / 1000;
                _context.Add(scratchCard);
                TempData["message"] = "Nạp thẻ thành công, vui lòng vào lịch sử để kiểm tra giao dịch !!!";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index), scratchCard);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MoMo(string Amount)
        {
            int amountInt = Int32.Parse(Amount);
            if (amountInt < 1000 || amountInt > 20000000)
                return RedirectToAction(nameof(Index));

            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMO3R5720190725";
            string accessKey = "ZarJz6vwlJUijSih";
            string serectkey = "XcCyHTwk2JXwXZQkDY3but2On0HKjqyQ";
            string orderInfo = "Nạp tiền nè các bạn";
            string returnUrl = "https://localhost:44372/Payment/MomoCallback";
            string notifyurl = "https://momo.vn/notify";

            string amount = Amount;
            string orderid = Guid.NewGuid().ToString();
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };
            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());
            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());

            // return View();
        }

        public IActionResult MoMoCallback(string partnerCode, string accessKey, string orderId, string localMessage, string message, string transId,
            string orderInfo, string amount, string errorCode, string responseTime, string requestId, string extraData, string payType, string orderType,
            string signature)
        {
            string rawHash = "partnerCode=" + partnerCode + "&accessKey=" + accessKey + "&requestId=" + requestId + "&amount=" + amount + "&orderId=" + orderId + "&orderInfo=" + orderInfo +
        "&orderType=" + orderType + "&transId=" + transId + "&message=" + message + "&localMessage=" + localMessage + "&responseTime=" + responseTime + "&errorCode=" + errorCode +
        "&payType=" + payType + "&extraData=" + extraData;

            string serectkey = "XcCyHTwk2JXwXZQkDY3but2On0HKjqyQ";
            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string partnerSignature = crypto.signSHA256(rawHash, serectkey);

            if (signature.Equals(partnerSignature))
            {
                // Lưu dữ liệu lại nè:
                Recharge recharge = new Recharge();
                recharge.User = this.GetCurrentUser();
                recharge.Amount = Int32.Parse(amount);
                recharge.Type = "MoMo";
                recharge.Money = recharge.Amount / 1000;
                recharge.User.Gold += recharge.Money;
                _context.Add(recharge);
                _context.SaveChanges();

                // Di chuyển sang lịch sử giao dịch nha
                return RedirectToAction(nameof(History));
            }
            else
                return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> History()
        {
            ViewData["user"] = this.GetCurrentUser();
            var userId = this.GetCurrentUser().Id;
            return View(await _context.Recharges
                .Where(s => s.User.Id == userId)
                .OrderByDescending(x => x.Id)
                .ToListAsync());
        }
    }
}
