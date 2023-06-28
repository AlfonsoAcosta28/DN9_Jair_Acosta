CREATE VIEW ProductInventoryView AS
SELECT inv.idInv, p.nom_proTyp AS tipo_producto, inv.cant_Inv
FROM inventory inv
INNER JOIN producttypes p ON inv.idProTyp = p.idProTyp;
