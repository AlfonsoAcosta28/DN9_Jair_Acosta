SELECT u.nom_usu AS nombre_usuario, m.fi_meb AS fecha_registro, mt.nom_MemT AS tipo_membresia
FROM members m
INNER JOIN user u ON m.idUser = u.idUser
INNER JOIN membershiptype mt ON m.idMemTyp = mt.idMemTyp
ORDER BY m.fi_meb DESC
LIMIT 1;
