-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: vehicles
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
-- Table structure for table `color`
--

DROP TABLE IF EXISTS `color`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `color` (
  `idcolor` int NOT NULL,
  `name` varchar(100) NOT NULL,
  `code` varchar(5) NOT NULL,
  `colorcol` varchar(45) NOT NULL,
  PRIMARY KEY (`idcolor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `color`
--

LOCK TABLES `color` WRITE;
/*!40000 ALTER TABLE `color` DISABLE KEYS */;
/*!40000 ALTER TABLE `color` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `incentive`
--

DROP TABLE IF EXISTS `incentive`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `incentive` (
  `idincentive` int NOT NULL,
  PRIMARY KEY (`idincentive`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `incentive`
--

LOCK TABLES `incentive` WRITE;
/*!40000 ALTER TABLE `incentive` DISABLE KEYS */;
/*!40000 ALTER TABLE `incentive` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory` (
  `idinventory` int NOT NULL,
  `color_idcolor` int NOT NULL,
  `vehicle_idvehicle` int NOT NULL,
  `price` decimal(13,2) DEFAULT NULL,
  PRIMARY KEY (`idinventory`),
  KEY `fk_inventory_color1_idx` (`color_idcolor`),
  KEY `fk_inventory_vehicle1_idx` (`vehicle_idvehicle`),
  CONSTRAINT `fk_inventory_color1` FOREIGN KEY (`color_idcolor`) REFERENCES `color` (`idcolor`),
  CONSTRAINT `fk_inventory_vehicle1` FOREIGN KEY (`vehicle_idvehicle`) REFERENCES `vehicle` (`idvehicle`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `make`
--

DROP TABLE IF EXISTS `make`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `make` (
  `idmake` int NOT NULL,
  `makename` varchar(100) NOT NULL,
  `county` varchar(100) NOT NULL,
  PRIMARY KEY (`idmake`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `make`
--

LOCK TABLES `make` WRITE;
/*!40000 ALTER TABLE `make` DISABLE KEYS */;
/*!40000 ALTER TABLE `make` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `model`
--

DROP TABLE IF EXISTS `model`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `model` (
  `idmodel` int NOT NULL,
  `modelname` varchar(500) NOT NULL,
  `firstproductionyear` int NOT NULL,
  PRIMARY KEY (`idmodel`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `model`
--

LOCK TABLES `model` WRITE;
/*!40000 ALTER TABLE `model` DISABLE KEYS */;
/*!40000 ALTER TABLE `model` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vehicle`
--

DROP TABLE IF EXISTS `vehicle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vehicle` (
  `idvehicle` int NOT NULL,
  `make_idmake` int NOT NULL,
  `model_idmodel` int NOT NULL,
  `year` int NOT NULL,
  PRIMARY KEY (`idvehicle`),
  KEY `fk_vehicle_make_idx` (`make_idmake`),
  KEY `fk_vehicle_model1_idx` (`model_idmodel`),
  CONSTRAINT `fk_vehicle_make` FOREIGN KEY (`make_idmake`) REFERENCES `make` (`idmake`),
  CONSTRAINT `fk_vehicle_model1` FOREIGN KEY (`model_idmodel`) REFERENCES `model` (`idmodel`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehicle`
--

LOCK TABLES `vehicle` WRITE;
/*!40000 ALTER TABLE `vehicle` DISABLE KEYS */;
/*!40000 ALTER TABLE `vehicle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vehicleincentive`
--

DROP TABLE IF EXISTS `vehicleincentive`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vehicleincentive` (
  `idvehicleincentive` int NOT NULL,
  `vehicle_idvehicle` int NOT NULL,
  `incentive_idincentive` int NOT NULL,
  `validtill` datetime DEFAULT NULL,
  PRIMARY KEY (`idvehicleincentive`,`vehicle_idvehicle`,`incentive_idincentive`),
  KEY `fk_hehicleincentive_vehicle1_idx` (`vehicle_idvehicle`),
  KEY `fk_vehicleincentive_incentive1_idx` (`incentive_idincentive`),
  CONSTRAINT `fk_hehicleincentive_vehicle1` FOREIGN KEY (`vehicle_idvehicle`) REFERENCES `vehicle` (`idvehicle`),
  CONSTRAINT `fk_vehicleincentive_incentive1` FOREIGN KEY (`incentive_idincentive`) REFERENCES `incentive` (`idincentive`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehicleincentive`
--

LOCK TABLES `vehicleincentive` WRITE;
/*!40000 ALTER TABLE `vehicleincentive` DISABLE KEYS */;
/*!40000 ALTER TABLE `vehicleincentive` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'vehicles'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-27 13:58:22
