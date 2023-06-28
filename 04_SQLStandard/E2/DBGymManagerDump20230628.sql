-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: dbgymmanager
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cities`
--

DROP TABLE IF EXISTS `cities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cities` (
  `idCities` int NOT NULL AUTO_INCREMENT,
  `nom_cit` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idCities`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cities`
--

LOCK TABLES `cities` WRITE;
/*!40000 ALTER TABLE `cities` DISABLE KEYS */;
INSERT INTO `cities` VALUES (1,'Ciudad de México'),(2,'Aguascalientes'),(3,'Monterrey'),(4,'Guadalajara'),(5,'Puebla');
/*!40000 ALTER TABLE `cities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipmenttype`
--

DROP TABLE IF EXISTS `equipmenttype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipmenttype` (
  `id_equiTyp` int NOT NULL AUTO_INCREMENT,
  `nom_equiTyp` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_equiTyp`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipmenttype`
--

LOCK TABLES `equipmenttype` WRITE;
/*!40000 ALTER TABLE `equipmenttype` DISABLE KEYS */;
INSERT INTO `equipmenttype` VALUES (1,'Pesas'),(2,'Pesas rusas'),(3,'Foam Rollers'),(4,'Caminadora'),(5,'Máquina de remo');
/*!40000 ALTER TABLE `equipmenttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory` (
  `idInv` int NOT NULL AUTO_INCREMENT,
  `idProTyp` int NOT NULL,
  `cant_Inv` int NOT NULL,
  PRIMARY KEY (`idInv`),
  KEY `fk_Inventory_ProductTypes1_idx` (`idProTyp`),
  CONSTRAINT `fk_Inventory_ProductTypes1` FOREIGN KEY (`idProTyp`) REFERENCES `producttypes` (`idProTyp`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (1,1,10),(2,2,5),(3,3,20),(4,4,8),(5,5,15);
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `measuretype`
--

DROP TABLE IF EXISTS `measuretype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `measuretype` (
  `idMeaTyp` int NOT NULL AUTO_INCREMENT,
  `nom_meaTyp` varchar(45) NOT NULL,
  PRIMARY KEY (`idMeaTyp`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `measuretype`
--

LOCK TABLES `measuretype` WRITE;
/*!40000 ALTER TABLE `measuretype` DISABLE KEYS */;
INSERT INTO `measuretype` VALUES (1,'10'),(2,'50'),(3,'100'),(4,'500'),(5,'1');
/*!40000 ALTER TABLE `measuretype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `members`
--

DROP TABLE IF EXISTS `members`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `members` (
  `idMembers` int NOT NULL AUTO_INCREMENT,
  `fi_meb` datetime NOT NULL,
  `ff_meb` datetime NOT NULL,
  `idUser` int NOT NULL,
  `idMemTyp` int NOT NULL,
  PRIMARY KEY (`idMembers`),
  KEY `fk_Members_User1_idx` (`idUser`),
  KEY `fk_Members_MembershipType1_idx` (`idMemTyp`),
  CONSTRAINT `fk_Members_MembershipType1` FOREIGN KEY (`idMemTyp`) REFERENCES `membershiptype` (`idMemTyp`),
  CONSTRAINT `fk_Members_User1` FOREIGN KEY (`idUser`) REFERENCES `user` (`idUser`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `members`
--

LOCK TABLES `members` WRITE;
/*!40000 ALTER TABLE `members` DISABLE KEYS */;
INSERT INTO `members` VALUES (1,'2022-01-01 00:00:00','2022-12-31 00:00:00',1,1),(2,'2022-02-01 00:00:00','2022-03-31 00:00:00',2,2),(3,'2022-03-01 00:00:00','2022-06-30 00:00:00',3,1),(4,'2022-04-01 00:00:00','2022-05-31 00:00:00',4,2),(5,'2022-05-01 00:00:00','2022-12-31 00:00:00',5,1);
/*!40000 ALTER TABLE `members` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `membershiptype`
--

DROP TABLE IF EXISTS `membershiptype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `membershiptype` (
  `idMemTyp` int NOT NULL AUTO_INCREMENT,
  `nom_MemT` varchar(45) NOT NULL,
  PRIMARY KEY (`idMemTyp`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `membershiptype`
--

LOCK TABLES `membershiptype` WRITE;
/*!40000 ALTER TABLE `membershiptype` DISABLE KEYS */;
INSERT INTO `membershiptype` VALUES (1,'Básica'),(2,'Premium'),(3,'Familiar'),(4,'Corporativa'),(5,'Estudiantil');
/*!40000 ALTER TABLE `membershiptype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `productinventoryview`
--

DROP TABLE IF EXISTS `productinventoryview`;
/*!50001 DROP VIEW IF EXISTS `productinventoryview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `productinventoryview` AS SELECT 
 1 AS `idInv`,
 1 AS `tipo_producto`,
 1 AS `cant_Inv`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `producttypes`
--

DROP TABLE IF EXISTS `producttypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `producttypes` (
  `idProTyp` int NOT NULL AUTO_INCREMENT,
  `nom_proTyp` varchar(45) NOT NULL,
  `idMeaTyp` int NOT NULL,
  PRIMARY KEY (`idProTyp`),
  KEY `fk_ProductTypes_MeasureType1_idx` (`idMeaTyp`),
  CONSTRAINT `fk_ProductTypes_MeasureType1` FOREIGN KEY (`idMeaTyp`) REFERENCES `measuretype` (`idMeaTyp`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producttypes`
--

LOCK TABLES `producttypes` WRITE;
/*!40000 ALTER TABLE `producttypes` DISABLE KEYS */;
INSERT INTO `producttypes` VALUES (1,'Proteínas',5),(2,'Batidos',3),(3,'Suplementos',4),(4,'Barritas energéticas',2),(5,'Multivitamínicos',1);
/*!40000 ALTER TABLE `producttypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `idRoles` int NOT NULL AUTO_INCREMENT,
  `nomRol` varchar(45) NOT NULL,
  PRIMARY KEY (`idRoles`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Administrador'),(2,'Contador'),(3,'Obrero'),(4,'Instructor'),(5,'Recepcionista');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sale`
--

DROP TABLE IF EXISTS `sale`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sale` (
  `idSale` int NOT NULL AUTO_INCREMENT,
  `idMembers` int NOT NULL,
  `fec_Sale` datetime NOT NULL,
  `tot_Sale` double DEFAULT NULL,
  PRIMARY KEY (`idSale`),
  KEY `fk_Sale_Members1_idx` (`idMembers`),
  CONSTRAINT `fk_Sale_Members1` FOREIGN KEY (`idMembers`) REFERENCES `members` (`idMembers`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sale`
--

LOCK TABLES `sale` WRITE;
/*!40000 ALTER TABLE `sale` DISABLE KEYS */;
INSERT INTO `sale` VALUES (1,1,'2022-01-01 00:00:00',50),(2,2,'2022-02-15 00:00:00',75),(3,3,'2022-03-20 00:00:00',120),(4,4,'2022-04-10 00:00:00',90),(5,5,'2022-05-05 00:00:00',60);
/*!40000 ALTER TABLE `sale` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `saleline`
--

DROP TABLE IF EXISTS `saleline`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `saleline` (
  `num_SaleLine` int NOT NULL AUTO_INCREMENT,
  `idProTyp` int NOT NULL,
  `cant_SaleLine` int NOT NULL,
  `subTot_saleLine` double(10,2) NOT NULL,
  `idSale` int NOT NULL,
  PRIMARY KEY (`num_SaleLine`),
  KEY `fk_SaleLine_ProductTypes1_idx` (`idProTyp`),
  KEY `fk_SaleLine_Sale1_idx` (`idSale`),
  CONSTRAINT `fk_SaleLine_ProductTypes1` FOREIGN KEY (`idProTyp`) REFERENCES `producttypes` (`idProTyp`),
  CONSTRAINT `fk_SaleLine_Sale1` FOREIGN KEY (`idSale`) REFERENCES `sale` (`idSale`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `saleline`
--

LOCK TABLES `saleline` WRITE;
/*!40000 ALTER TABLE `saleline` DISABLE KEYS */;
INSERT INTO `saleline` VALUES (1,1,2,20.00,1),(2,2,1,10.00,1),(3,3,3,30.00,2),(4,4,1,15.00,3),(5,5,2,25.00,4),(6,5,2,45.00,5);
/*!40000 ALTER TABLE `saleline` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `idUser` int NOT NULL AUTO_INCREMENT,
  `nom_usu` varchar(45) DEFAULT NULL,
  `ap_usu` varchar(45) NOT NULL,
  `am_usu` varchar(45) NOT NULL,
  `email_usu` varchar(45) NOT NULL,
  `tel_usu` varchar(45) NOT NULL,
  `idCities` int NOT NULL,
  PRIMARY KEY (`idUser`),
  KEY `fk_User_Cities1_idx` (`idCities`),
  CONSTRAINT `fk_User_Cities1` FOREIGN KEY (`idCities`) REFERENCES `cities` (`idCities`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Juan','Pérez','González','juan@example.com','555-123-4567',1),(2,'María','López','García','maria@example.com','555-987-6543',2),(3,'Pedro','Martínez','Sánchez','pedro@example.com','555-555-5555',3),(4,'Laura','González','Hernández','laura@example.com','555-111-2222',4),(5,'Carlos','Fernández','Rodríguez','carlos@example.com','555-777-8888',5);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userinroles`
--

DROP TABLE IF EXISTS `userinroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userinroles` (
  `idUserInRoles` int NOT NULL AUTO_INCREMENT,
  `idUser` int NOT NULL,
  `idRoles` int NOT NULL,
  PRIMARY KEY (`idUserInRoles`),
  KEY `idUser_idx` (`idUser`),
  KEY `idRoles_idx` (`idRoles`),
  CONSTRAINT `idRoles` FOREIGN KEY (`idRoles`) REFERENCES `roles` (`idRoles`),
  CONSTRAINT `idUser` FOREIGN KEY (`idUser`) REFERENCES `user` (`idUser`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userinroles`
--

LOCK TABLES `userinroles` WRITE;
/*!40000 ALTER TABLE `userinroles` DISABLE KEYS */;
INSERT INTO `userinroles` VALUES (1,1,1),(2,2,2),(3,3,3),(4,4,4),(5,5,5);
/*!40000 ALTER TABLE `userinroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `userrolesview`
--

DROP TABLE IF EXISTS `userrolesview`;
/*!50001 DROP VIEW IF EXISTS `userrolesview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `userrolesview` AS SELECT 
 1 AS `idUser`,
 1 AS `nombre`,
 1 AS `email_usu`,
 1 AS `tel_usu`,
 1 AS `nomRol`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping routines for database 'dbgymmanager'
--

--
-- Final view structure for view `productinventoryview`
--

/*!50001 DROP VIEW IF EXISTS `productinventoryview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `productinventoryview` AS select `inv`.`idInv` AS `idInv`,`p`.`nom_proTyp` AS `tipo_producto`,`inv`.`cant_Inv` AS `cant_Inv` from (`inventory` `inv` join `producttypes` `p` on((`inv`.`idProTyp` = `p`.`idProTyp`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `userrolesview`
--

/*!50001 DROP VIEW IF EXISTS `userrolesview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `userrolesview` AS select `u`.`idUser` AS `idUser`,concat(`u`.`nom_usu`,' ',`u`.`ap_usu`,' ',`u`.`am_usu`) AS `nombre`,`u`.`email_usu` AS `email_usu`,`u`.`tel_usu` AS `tel_usu`,`r`.`nomRol` AS `nomRol` from ((`user` `u` join `userinroles` `ur` on((`u`.`idUser` = `ur`.`idUser`))) join `roles` `r` on((`ur`.`idRoles` = `r`.`idRoles`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-28 15:40:22
