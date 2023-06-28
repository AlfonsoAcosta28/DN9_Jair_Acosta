CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllUsers`()
BEGIN
	Select * from users;
END