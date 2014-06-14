-- MySQL dump 10.13  Distrib 5.6.17, for Win64 (x86_64)
--
-- Host: localhost    Database: parroquiaantunez
-- ------------------------------------------------------
-- Server version	5.6.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bautismos`
--

DROP TABLE IF EXISTS `bautismos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bautismos` (
  `id_bautismo` int(11) NOT NULL AUTO_INCREMENT,
  `id_libro` int(11) DEFAULT NULL,
  `num_hoja` int(11) DEFAULT NULL,
  `num_partida` varchar(10) DEFAULT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `padre` varchar(100) DEFAULT NULL,
  `madre` varchar(100) DEFAULT NULL,
  `fecha_nac` date DEFAULT NULL,
  `lugar_nac` varchar(100) DEFAULT NULL,
  `fecha_bautismo` date DEFAULT NULL,
  `padrino` varchar(100) DEFAULT NULL,
  `madrina` varchar(100) DEFAULT NULL,
  `presbitero` varchar(100) DEFAULT NULL,
  `anotacion` text,
  `anio` varchar(100) DEFAULT NULL,
  `bis` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_bautismo`),
  KEY `id_libro` (`id_libro`),
  KEY `id_libro_2` (`id_libro`),
  CONSTRAINT `bautismos_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bautismos`
--

LOCK TABLES `bautismos` WRITE;
/*!40000 ALTER TABLE `bautismos` DISABLE KEYS */;
INSERT INTO `bautismos` VALUES (4,1,1,'1','FRANCISCO JAVIER CALDERON CHAVEZ','MARIO CALDERON MENDEZ','TERESA CHAVEZ HERNANDEZ','1991-11-24','NUEVA ITALIA MICHOACAN','1992-11-24','SERGIO PARDO','VENEDA CHAVEZ','NO ME ACUERDO DEL PADRE','NO RECUERDA EL PADRE EN ANOTACIONES','1992',0),(5,1,1,'2','AMNDMB','NBANMSDBN','NNMSBNAM','2014-05-26','NABSDNDSABDN','2014-05-26','MNANMSDBN','MNBNASDBN','BNMASBNDBSN','MNNMABSDNMSABD','2014',0),(6,3,1,'3','JUAN PEREZ MOTA A','JONATHAN PEREZ A','MARIA MOTA A ','1999-11-17','APATZINGANA','2000-02-17','PADRINO A','MADRINA A','PRESBITEROA','NO ES VERDAD QA','2000',0),(7,1,1,'4','JESUS','DESCONOCIDO','DESCONOCIDA','2014-05-26','APATZINGAN','2014-05-26','JOSE','JOSEGA','JUAN','NADA','',0),(8,3,1,'5','ADAJSDKLSADJKKKKKKKKKKHJJJJJ','LKJASLKDJASKLDJ','LKJLKASJDKASLDJ','2014-05-26','KASJDKLASDKLSAJ','2014-05-26','KJAKLSDJSAKLDJ','KJALKSDJSALKDJ','KLJALKSD','','2014',0),(9,3,1,'6','JESUS SANCHEZ SOTO','JESUS','JOSE','2014-05-26','APATZINGAN','2014-05-26','JUAN','PEDRO','PABLO','','2014',0),(10,3,1,'7','ALFONSO CALDERON CHAVEZ','MARIO CALDERON MENDEZ','TERESA CHAVEZ HERNANDEZ','2014-09-26','APATZINGAN','2014-09-26','REYES','SILVIA','PABLO','NOTAS MARGINALES DE NUEVO REVISANDO ESTA COSA, PARA VER SI SE REALIZAN AVANCES EN TODO ESTO, PORQUE ESTO NO SE PUEDE DEJAR SIN HACER ALGO, Y SOLO QUIERE ESCRIBIR, ESCRIBIR Y ESCRIBIR TODO LO QUE PUEDA','1991',0),(11,3,1,'8','ASDHKJJ','HJAHDJHSJHKA','JASHDJSAHD','2014-05-26','AKJSHDJKSAHD','2014-05-26','AJKSDHJKSAD','JAJKSDHJKASHD','JKHASKJDHJKSAD','','2014',0),(12,3,1,'9','JAKDHSAJKHJ','HJKAHSDJKH','JKHAJKSDHJKSA','2014-05-26','JKHASDJKHSAJKDH','2014-05-26','JHKJASHDJKSAHKJ','HKJASHDJKSAHD','KJAKJHSDJKSAHD','','2014',0),(13,3,1,'10','JESUS CHAVEZ','JESUS','IRENE','2014-05-26','EL CEÑIDOR','2014-05-26','JUA','PEDRO','JOSEFA','','2014',0),(14,3,2,'11','ALKDASKDJKASKLD','KJASLKDJASLKDJ','KJKALSDJAKSLDJ','2014-05-26','SKDALKJASKLDJKL','2014-05-26','KJASKDJASKLDJAS','KASSJDKLASJDKL','DOPAIDSA','AKDASKLDJ','2014',0),(15,3,2,'12','MARISOL SERNA GONZALEZ','ASJJDSAKJDHJK','KJASDJKASHDJKH','2014-05-26','JHASDKJSADHKJ','2014-05-26','KJASJKDHASJKDHSAJK','KJHASJKDHSAKJDH','KJHASKJDASJDASDKJASH','','2014',0),(16,3,1,'9BIS','LÑFKDLSÑKF','LKLKDLASDKL','KLALKDKLSAJKDL','2014-05-28','ASLKJDKLSADJKL','2014-05-28','KJASKLJDKLSJD','LKJALKSJDLKASJD','LKJAKLSDJKLASJD','KADJASKLDJKKL','2014',1),(17,3,1,'10','LKSFJLKDSFJ','JKJDFKLSJADKL','KJALKDJAKSLDJ','2014-05-28','LKJDKLFJASKLD','2014-05-28','KLJDLKJKAL','KLADFKLJAS','LKALKDJKASD','','2014',0),(18,3,2,'11','ALKDSAKLDJAKL','LKASLKDLKSAJ','LKLKASJDKLJAS','2014-05-28','LKJDKLDASKLDJ','2014-05-28','LKJASLKDJSAKL','KLJLKASJDKLASJ','LKJALKSJDKASL','LJKLASJDLKASJD','2014',0),(19,3,2,'11BIS','ZLKDCKKLLKKL','LKSDKLFSKJFKJSDKJ','LKSDLFDSKFK','2014-05-28','LKDFJKDSKLFALK','2014-05-28','LKAJLKLADKSKL','KLAKDJKASKDJKL','KAJDKLSADJK','','2014',1),(20,3,2,'12','SDLKFKDFK','KLSDLKFALKLK','LKSDKLFKJA','2014-05-28','KLSDFLKJSL','2014-05-28','LKJKALJFKLJ','JKSLDJFKLAJ','KLJKLSJDKLSAJD','','2014',0),(21,3,2,'13','WFPEQOP','OOEFO','OOOSDFO','2014-05-28','ODFO','2014-05-28','OPADO','OADO','OAOPDOAA','','2014',0),(22,3,2,'14','ASKJDHSAKJH','HJKASHDJKASH','JJKAHSDJKHJKHJKAH','2014-05-29','JHASJKDH','2014-05-29','JHJKASHDJK','HJKHAJKSDHJK','HJKAHSJKDSA','','2014',0),(23,3,2,'15','LKDSKFDSKJJKKJKJKJJJJJ','KLASJDLKASJKL','JKLASJDKL','2014-05-29','KLASDLKJASDLJ','2014-05-29','KJKASLJDKLSAJDLK','JKLASJDKLASJDKLJ','KLJASKLDJSKALDJKASL','','2014',0),(24,3,2,'16','HHHHHHHHHHHHHHHH','HHHHHHHHHHHHHHHHHH','HHHHHHHHHHHHHH','2014-05-30','HHHHHHHHHHHHHHHHHH','2014-05-30','HHHHHHHHHHHHHHHHHHH','HHHHHHHHHHHHHHHHHH','HHHHHHHHHHHHHHHHHHHH','','2014',0),(25,3,2,'17','K.-----------------','--------------','-------------','2014-05-30','------------------','2014-05-30','-------------------','--------------------','--------------------','','2014',0),(26,3,2,'18','--------------------------','----------------------','----------------------------','2014-05-30','----------------------','2014-05-30','------------------','-------------------------','-----------------------','','2014',0),(27,3,2,'19','SDFSD','SDFSDF','FSDF','2014-06-02','FSDFSDFSD','2014-06-02','SDF','SDFSDFS','FSD','SFDDSF','2014',0),(28,3,2,'20','HOLA MUNDO','HOLA MUNDO','HOLA MUNDA','2014-06-02','ASDA','2014-06-02','DSAD','SADSAD','ASD','ADASD','2014',0);
/*!40000 ALTER TABLE `bautismos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categorias`
--

DROP TABLE IF EXISTS `categorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categorias` (
  `id_categoria` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_categoria` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorias`
--

LOCK TABLES `categorias` WRITE;
/*!40000 ALTER TABLE `categorias` DISABLE KEYS */;
INSERT INTO `categorias` VALUES (1,'BAUTISMO'),(2,'CONFIRMACIÓN'),(3,'PRIMERA COMUNION'),(4,'MATRIMONIO');
/*!40000 ALTER TABLE `categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comuniones`
--

DROP TABLE IF EXISTS `comuniones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comuniones` (
  `id_comunion` int(11) NOT NULL AUTO_INCREMENT,
  `id_libro` int(11) NOT NULL,
  `num_hoja` int(11) NOT NULL,
  `num_partida` varchar(10) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `padre` varchar(100) NOT NULL,
  `madre` varchar(100) NOT NULL,
  `fecha_comunion` date NOT NULL,
  `fecha_bautismo` date NOT NULL,
  `lugar_bautismo` varchar(100) NOT NULL,
  `padrino` varchar(100) NOT NULL,
  `madrina` varchar(100) NOT NULL,
  `anio` varchar(10) NOT NULL,
  `bis` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_comunion`),
  KEY `id_libro` (`id_libro`),
  CONSTRAINT `comuniones_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comuniones`
--

LOCK TABLES `comuniones` WRITE;
/*!40000 ALTER TABLE `comuniones` DISABLE KEYS */;
INSERT INTO `comuniones` VALUES (1,11,1,'1','FRANCISCO JAVIER CALDERON CHAVEZ','=======================','TERESA CHAVEZ HERNANDEZ','1997-12-12','1991-11-24','EL CEÑIDOR MICHOACAN','SERGIO PARDO MENERA','==========','2014',0),(2,12,1,'2','WATASHI NAKATA NO','ZOKKA TAKOMU','NIOJO AKATA ','1997-12-12','1901-11-24','ANTUNEZ MICHOACAN','AANG TORILLA MA','KATARA UZUMAKI','1997',0),(3,12,1,'3','ASD ASDSA','SDFSD','FDSF SF','2014-05-25','1991-12-19','SDFSDF','SDFSD','FDSF','1997',0),(4,12,1,'4','FYG','GFDFQ','YGYT','2014-05-25','2014-05-25','UYUYT','1TYF','YGF','',0),(5,12,1,'5','HJG','HJG','JHG','2014-05-25','2014-05-25','JHGJ','HGJ','HGJH','1997',0),(6,12,1,'6','K','KJH','KJHKJ','2014-05-25','2014-05-25','HKJ','HKJ','HJK','1997',0),(7,12,1,'7','POI','OPII','IOP','2014-05-25','2014-05-25','POIPOI','POI','RTER','1997',0),(8,12,1,'8','TRE','TR','RERER','2014-05-25','2014-05-25','RYT','RYTR','YT','1997',0),(9,12,1,'9','TR','RT','RT','2014-05-25','2014-05-25','T','TRE','TR','1997',0),(10,12,1,'10','T','TR','TYR','2014-05-25','2014-05-25','R','YTR','YT','1997',0),(11,11,2,'11','DFD','ASD','ADDDDD DSDASD','2014-05-25','2014-05-25','FGD','FGDGFD','GFDGFD','2013',0),(12,12,2,'12','ALFONSO CALDERON CHAVEZ',' MARIO','TERESA CHAVEZ','2013-05-27','2014-05-27','EL CEÑIDOR MICHOACAN','FELIIPE CALDERON','ESTHER GORDILLO','2014',0),(13,12,2,'13','KKKKKKKK','KAKDKLASDKLSADK','KJKASJDKLASJD','2014-05-27','2014-05-27','KADKASJDSA','ASDASDJASKLDJASASDASLD','KJAKLSDASLKDJ','2014',0),(14,12,2,'12','DKKFDJSKLJ','JKLSDJFKLJ','KLJSKDLJ','2014-05-29','2014-05-29','ASDSKAJDKL','=============','LKJSDJSALKDJASLKDJ','2014',0),(15,12,2,'13','HJKDSDASJH','JKHKAJSDHASKJH','QKJHAKSJDHKJAS','2014-05-30','2014-05-30','KJAHSDKJSAHD','KJHAKJSDHSKJAH','KJHAKSJHDAS','2014',0),(16,12,2,'14','KXJHKJHKJHKJHKJHKJ','HJHKJHJKHJKHKJHKJ','HHJHJHJKKJH','2014-05-30','2014-05-30','KJHJKHHKJHKJHJK','HJHJHJKJKHHKJHJK','HKJHJKHJKHJKJKH','2014',0),(17,12,2,'15','HOLA ','NADA DE NADA','NO SE','2014-06-02','2014-06-02','KLAJSDKLAJSDKL','LKAJDLKASJD LAKSJD LKSADJ','LKJ ASLDKJ ASLKDJASLKD','2014',0),(18,12,2,'16','ASDSADASD','ADSADSADSAD SA DSA ','DSA D SAD SA DSA D','2014-06-02','2014-06-02','AS SA DSA SA DSA','DSA DSA D','SA DSA DSA D','2014',0);
/*!40000 ALTER TABLE `comuniones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `confirmaciones`
--

DROP TABLE IF EXISTS `confirmaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `confirmaciones` (
  `id_confirmacion` int(11) NOT NULL AUTO_INCREMENT,
  `id_libro` int(11) NOT NULL,
  `num_hoja` int(11) NOT NULL,
  `num_partida` varchar(10) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `padre` varchar(100) NOT NULL,
  `madre` varchar(100) NOT NULL,
  `fecha_confirmacion` date NOT NULL,
  `fecha_bautismo` date NOT NULL,
  `lugar_bautismo` varchar(100) NOT NULL,
  `padrino` varchar(100) NOT NULL,
  `madrina` varchar(100) NOT NULL,
  `presbitero` varchar(100) NOT NULL,
  `anio` varchar(10) NOT NULL,
  `bis` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_confirmacion`),
  KEY `id_libro` (`id_libro`),
  KEY `id_libro_2` (`id_libro`),
  CONSTRAINT `confirmaciones_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `confirmaciones`
--

LOCK TABLES `confirmaciones` WRITE;
/*!40000 ALTER TABLE `confirmaciones` DISABLE KEYS */;
INSERT INTO `confirmaciones` VALUES (1,7,1,'1','','','','2014-05-26','2014-05-26','','','','','',0),(2,7,1,'2','ALFONSO CALDERON CHAVEZ','=============','TERESA CHAVEZ','2010-12-15','2010-05-26','APATZINGAN','==========','MADRINA 2 PEREZ DE LA O','ASKDSADKJLL','2014',0),(3,7,1,'3','KKKKLLLLLLLLLLL','LKASJDKLASJDLLLLLLLL','LLLLLLLLLLLLLL','2014-05-26','2014-05-26','LLLLLLLLLLLLLLLL','LLLLLLLLLLLLLLLLL','LLLLLLLLLLLLLLL','LLLLLLLLLLLLLLL','2014',0);
/*!40000 ALTER TABLE `confirmaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `coordenadas`
--

DROP TABLE IF EXISTS `coordenadas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `coordenadas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoria` int(11) NOT NULL,
  `formato` int(11) NOT NULL,
  `x` int(11) NOT NULL,
  `y` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `categoria` (`categoria`),
  CONSTRAINT `coordenadas_ibfk_1` FOREIGN KEY (`categoria`) REFERENCES `categorias` (`id_categoria`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `coordenadas`
--

LOCK TABLES `coordenadas` WRITE;
/*!40000 ALTER TABLE `coordenadas` DISABLE KEYS */;
INSERT INTO `coordenadas` VALUES (1,1,1,0,0),(2,2,1,0,0),(3,3,1,0,0),(4,4,1,2,2),(5,1,2,0,2);
/*!40000 ALTER TABLE `coordenadas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `egresos`
--

DROP TABLE IF EXISTS `egresos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `egresos` (
  `fecha` date NOT NULL,
  `concepto` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  PRIMARY KEY (`fecha`,`concepto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `egresos`
--

LOCK TABLES `egresos` WRITE;
/*!40000 ALTER TABLE `egresos` DISABLE KEYS */;
INSERT INTO `egresos` VALUES ('2014-02-08',6,56),('2014-02-14',14,10),('2014-02-17',12,12),('2014-02-19',16,56),('2014-02-24',10,34),('2014-02-25',16,23),('2014-02-27',18,10),('2014-06-01',2,23.98),('2014-06-01',6,2323),('2014-06-01',9,12.11),('2014-06-02',2,0.99),('2014-06-02',4,56),('2014-06-03',2,3499),('2014-06-04',3,78.9),('2014-06-05',5,345),('2014-06-06',4,23434),('2014-06-06',6,0),('2014-06-07',8,3434),('2014-06-08',5,56),('2014-06-10',12,4334),('2014-06-11',3,45),('2014-06-12',7,0),('2014-06-12',8,123.9),('2014-06-13',6,5),('2014-06-13',9,34),('2014-06-13',10,34),('2014-06-13',12,34),('2014-06-14',5,5),('2014-06-14',6,3),('2014-06-14',7,56),('2014-06-14',10,3),('2014-06-14',14,434),('2014-06-14',17,2134.987),('2014-06-15',10,4),('2014-06-16',2,34.76),('2014-06-17',6,1200),('2014-06-17',13,34),('2014-06-18',4,345),('2014-06-18',6,443),('2014-06-18',8,43),('2014-06-18',11,3000),('2014-06-19',8,3),('2014-06-19',12,34),('2014-06-20',2,3434),('2014-06-20',14,4976),('2014-06-21',10,43),('2014-06-21',12,34),('2014-06-21',14,43),('2014-06-22',4,23.76),('2014-06-23',4,23.09),('2014-06-23',18,56.78),('2014-06-24',13,5675),('2014-06-26',7,45.87),('2014-06-27',10,3449),('2014-06-27',11,984),('2014-06-27',16,6794),('2014-06-27',18,34.65),('2014-06-29',2,12998),('2014-06-29',18,11.12),('2014-06-30',11,10),('2014-06-30',18,23.12);
/*!40000 ALTER TABLE `egresos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `informacion`
--

DROP TABLE IF EXISTS `informacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `informacion` (
  `nombre_parroquia` varchar(100) NOT NULL,
  `nombre_parroco` varchar(100) NOT NULL,
  `ubicacion_parroquia` varchar(100) NOT NULL,
  `ubicacion_carpeta` varchar(100) NOT NULL,
  `contrasena` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `informacion`
--

LOCK TABLES `informacion` WRITE;
/*!40000 ALTER TABLE `informacion` DISABLE KEYS */;
INSERT INTO `informacion` VALUES ('Ntra. Sra. de Gpe.','Antonio Mendoza','Antúnez, Michoacán','c:/DOCsParroquia','4255925238');
/*!40000 ALTER TABLE `informacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `libros`
--

DROP TABLE IF EXISTS `libros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `libros` (
  `id_libro` int(11) NOT NULL AUTO_INCREMENT,
  `id_categoria` int(11) DEFAULT NULL,
  `nombre_libro` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_libro`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `libros`
--

LOCK TABLES `libros` WRITE;
/*!40000 ALTER TABLE `libros` DISABLE KEYS */;
INSERT INTO `libros` VALUES (1,1,'LIBRO 1'),(3,1,'LIBRO 2'),(7,2,'2'),(8,4,'LIBRO 1'),(9,4,'LIBRO 2'),(11,3,'1'),(12,3,'2');
/*!40000 ALTER TABLE `libros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `matrimonios`
--

DROP TABLE IF EXISTS `matrimonios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `matrimonios` (
  `id_matrimonio` int(11) NOT NULL AUTO_INCREMENT,
  `id_libro` int(11) NOT NULL,
  `num_hoja` int(11) NOT NULL,
  `num_partida` varchar(10) NOT NULL,
  `novio` varchar(100) NOT NULL,
  `novia` varchar(100) NOT NULL,
  `fecha_matrimonio` date NOT NULL,
  `lugar_celebracion` varchar(100) NOT NULL,
  `testigo1` varchar(100) NOT NULL,
  `testigo2` varchar(100) NOT NULL,
  `asistente` varchar(100) NOT NULL,
  `nota_marginal` varchar(100) NOT NULL,
  `anio` varchar(10) NOT NULL,
  `bis` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_matrimonio`),
  KEY `id_libro` (`id_libro`),
  CONSTRAINT `matrimonios_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `matrimonios`
--

LOCK TABLES `matrimonios` WRITE;
/*!40000 ALTER TABLE `matrimonios` DISABLE KEYS */;
INSERT INTO `matrimonios` VALUES (1,8,1,'1','JAVIER CALDERON CHAVEZ','MARIBEL TORRES SAUCEDO','2016-06-15','EL CEÑIDOR','ALFONSO CALDERON','TERESA CHAVEZ','ARISAI BOTELLO','','2014',0),(2,8,1,'2','KJ SDKJFHDSKJFH SJDF H','H DSKJFHSKJDF SD FSDKFH SKJD FHK','2014-05-24','KJ SHFKJDSF HDSK FKJDSHF K',' SHDFKJ SHK',' HKSD HFKJ','H KJ HFK','','1991',0),(3,9,1,'3','LKADKLASJDKLSAJDK','KLJAKLSDJSAKLDJ','2014-05-27','KLASDLKJASKDLJ','KLJASLKDJASKDL','LKJAKLSDJSALK','LKJAKLSJDKSLAD','','',0),(4,8,1,'4','JAVIER CALDERON','MARIBEL TORRES','2012-05-14','EL CEÑIDOR','NOSE QUIEN TESTIGO 1','NOSE QUIEN TESTIGO 2','ASD ASISTENTE','','2012',0),(5,8,1,'5','JAVIER','MARIBEL','1991-11-24','CEÑIDOR EL','T1','T2','ASISTENTE','SE VOLVIERON A CASAR','1988',0),(6,9,1,'2','ALFONSO CALDERON','JUANA','2014-09-30','EL CEÑIDOR','ANTONIO','ANTONIA','ASLKDSALKDJ','ASLKDSALKD ASJDLKASJD KASJDSJADLSJK','2014',0),(7,9,1,'2BIS','LKASDJKASLJK','LJKLASDJKL','2014-05-30','KLAJSDLKSAJ','KLJALKSDJLK','LKJALKSJDLKAS','LKJALKSJDLKSAJ','LKJASLKDJSKALD','2014',1),(8,9,1,'3','IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII','KLJASDKJSAJD','2014-05-30','JKHASJKDHASKJ','JHSAJKDHKJAH','JKHAKJSDHASKJH','JHAJSKDHKJASH','','2014',0),(9,9,1,'4','DSKJH','KJASJKDJHK','2014-05-30','AJSKHDASJKDH','JHASKJDHKASJH','JHAKJSDHJK','HJKAHSDJHASJDK','','2014',0),(10,9,1,'5','OIWOIIOIO','II','2014-05-30','KJASDKJHHJK','IUOUIOIUOIUOWASD','JKASJDHASJKDJH','ASJDHKASKJDAKJSHKJ','','2014',0),(11,9,1,'6','SAJJK','JKLJ','2014-05-30','LKJLKJL','KJLKJ','LKJLKJ','LKJLKJ','LKJLKJ','2014',0);
/*!40000 ALTER TABLE `matrimonios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-06-13 19:06:59
