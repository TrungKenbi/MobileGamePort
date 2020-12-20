UPDATE dbo.Games SET LinkAndroid = '/filemanager/root/Files/Game.jar', LinkIOS = '/filemanager/root/Files/Game.jar'
GO
UPDATE dbo.Games SET Views = abs(checksum(NewId()) % 100000), Downloads = abs(checksum(NewId()) % 10000)
GO