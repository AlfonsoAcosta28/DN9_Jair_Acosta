CREATE DEFINER=`root`@`localhost` PROCEDURE `GetMembersLastWeek`()
BEGIN
	declare fi Date;
    declare ff Date;
    
    set fi = curdate() - interval weekday(curdate()) day;
    set ff = fi + interval 6 day;
    
    select * from members m inner join membershiptype mt on m.idMemTyp = mt.idMemTyp where m.fi_meb between fi and ff;
END