CREATE DEFINER=`root`@`localhost` PROCEDURE `NewSale`(in idPro int, in cant int,in idMem int)
BEGIN
	declare saleId int;
    declare precio int;
    
   Select precio_protyp into precio from producttypes where idProTyp = idPro;
	insert into sale values (null, idMem, now(), 0);
    set saleId = last_insert_id();
    insert into saleline values (null, idPro, cant, precio, saleId);
    update sale set tot_Sale = precio where idSale = saleId;
END