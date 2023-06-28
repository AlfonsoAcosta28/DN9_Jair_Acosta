SELECT p.nom_proTyp AS producto, COUNT(*) AS total_ventas
FROM saleline sl
INNER JOIN producttypes p ON sl.idProTyp = p.idProTyp
GROUP BY sl.idProTyp
HAVING COUNT(*) = (SELECT MAX(ventas) FROM (SELECT COUNT(*) AS ventas FROM saleline GROUP BY idProTyp) AS ventasTotales);
