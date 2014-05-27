-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: May 26, 2014 at 07:28 PM
-- Server version: 5.6.12-log
-- PHP Version: 5.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `parroquiaantunez`
--
CREATE DATABASE IF NOT EXISTS `parroquiaantunez` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `parroquiaantunez`;

-- --------------------------------------------------------

--
-- Table structure for table `bautismos`
--

CREATE TABLE IF NOT EXISTS `bautismos` (
  `id_bautismo` int(11) NOT NULL AUTO_INCREMENT,
  `id_libro` int(11) DEFAULT NULL,
  `num_hoja` int(11) DEFAULT NULL,
  `num_partida` int(11) DEFAULT NULL,
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
  PRIMARY KEY (`id_bautismo`),
  KEY `id_libro` (`id_libro`),
  KEY `id_libro_2` (`id_libro`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `bautismos`
--

INSERT INTO `bautismos` (`id_bautismo`, `id_libro`, `num_hoja`, `num_partida`, `nombre`, `padre`, `madre`, `fecha_nac`, `lugar_nac`, `fecha_bautismo`, `padrino`, `madrina`, `presbitero`, `anotacion`, `anio`) VALUES
(4, 1, 1, 1, 'FRANCISCO JAVIER CALDERON CHAVEZ', 'MARIO CALDERON MENDEZ', 'TERESA CHAVEZ HERNANDEZ', '1991-11-24', 'NUEVA ITALIA MICHOACAN', '1992-11-24', 'SERGIO PARDO', 'VENEDA CHAVEZ', 'NO ME ACUERDO DEL PADRE', 'NO RECUERDA EL PADRE EN ANOTACIONES', '1992'),
(5, 1, 1, 2, 'ALFONSO CALDERON CHAVEZ', 'MARIO CALDERON MENDEZ', 'TERESA CHAVEZ HERNANDEZ', '1990-06-04', 'APATZINGAN MICHOACAN', '1991-06-04', 'REYES NO RECUERDO NOMBRE', 'NO RECUERDO NOMBRE DE MADRINA', 'PRESBITERO PADRE RUBEN', '', '1990'),
(6, 3, 1, 3, 'JUAN PEREZ MOTA A', 'JONATHAN PEREZ A', 'MARIA MOTA A ', '1999-11-17', 'APATZINGANA', '2000-02-17', 'PADRINO A', 'MADRINA A', 'PRESBITEROA', 'NO ES VERDAD QA', '2000');

-- --------------------------------------------------------

--
-- Table structure for table `categorias`
--

CREATE TABLE IF NOT EXISTS `categorias` (
  `id_categoria` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_categoria` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_categoria`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `categorias`
--

INSERT INTO `categorias` (`id_categoria`, `nombre_categoria`) VALUES
(1, 'BAUTISMO'),
(2, 'CONFIRMACIÓN'),
(3, 'PRIMERA COMUNION'),
(4, 'MATRIMONIO');

-- --------------------------------------------------------

--
-- Table structure for table `comuniones`
--

CREATE TABLE IF NOT EXISTS `comuniones` (
  `id_comunion` int(11) NOT NULL AUTO_INCREMENT,
  `id_libro` int(11) NOT NULL,
  `num_hoja` int(11) NOT NULL,
  `num_partida` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `padre` varchar(100) NOT NULL,
  `madre` varchar(100) NOT NULL,
  `fecha_comunion` date NOT NULL,
  `fecha_bautismo` date NOT NULL,
  `lugar_bautismo` varchar(100) NOT NULL,
  `padrino` varchar(100) NOT NULL,
  `madrina` varchar(100) NOT NULL,
  `anio` varchar(10) NOT NULL,
  PRIMARY KEY (`id_comunion`),
  KEY `id_libro` (`id_libro`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=12 ;

--
-- Dumping data for table `comuniones`
--

INSERT INTO `comuniones` (`id_comunion`, `id_libro`, `num_hoja`, `num_partida`, `nombre`, `padre`, `madre`, `fecha_comunion`, `fecha_bautismo`, `lugar_bautismo`, `padrino`, `madrina`, `anio`) VALUES
(1, 11, 1, 1, 'FRANCISCO JAVIER CALDERON CHAVEZ', 'MARIO CALDERON MENDEZ', 'TERESA CHAVEZ HERNANDEZ', '1997-12-12', '1991-11-24', 'EL CEÑIDOR MICHOACAN', 'SERGIO PARDO', 'VENEDA CHAVEZ', '2014'),
(2, 12, 1, 2, 'WATASHI NAKATA NO', 'ZOKKA TAKOMU', 'NIOJO AKATA ', '1997-12-12', '1901-11-24', 'ANTUNEZ MICHOACAN', 'AANG TORILLA MA', 'KATARA UZUMAKI', '1997'),
(3, 12, 1, 3, 'ASD ASDSA', 'SDFSD', 'FDSF SF', '2014-05-25', '1991-12-19', 'SDFSDF', 'SDFSD', 'FDSF', '1997'),
(4, 12, 1, 4, 'FYG', 'GFDFQ', 'YGYT', '2014-05-25', '2014-05-25', 'UYUYT', '1TYF', 'YGF', '1997'),
(5, 12, 1, 5, 'HJG', 'HJG', 'JHG', '2014-05-25', '2014-05-25', 'JHGJ', 'HGJ', 'HGJH', '1997'),
(6, 12, 1, 6, 'K', 'KJH', 'KJHKJ', '2014-05-25', '2014-05-25', 'HKJ', 'HKJ', 'HJK', '1997'),
(7, 12, 1, 7, 'POI', 'OPII', 'IOP', '2014-05-25', '2014-05-25', 'POIPOI', 'POI', 'RTER', '1997'),
(8, 12, 1, 8, 'TRE', 'TR', 'RERER', '2014-05-25', '2014-05-25', 'RYT', 'RYTR', 'YT', '1997'),
(9, 12, 1, 9, 'TR', 'RT', 'RT', '2014-05-25', '2014-05-25', 'T', 'TRE', 'TR', '1997'),
(10, 12, 1, 10, 'T', 'TR', 'TYR', '2014-05-25', '2014-05-25', 'R', 'YTR', 'YT', '1997'),
(11, 11, 2, 11, 'DFD', 'ASD', 'ADDDDD DSDASD', '2014-05-25', '2014-05-25', 'FGD', 'FGDGFD', 'GFDGFD', '2013');

-- --------------------------------------------------------

--
-- Table structure for table `confirmaciones`
--

CREATE TABLE IF NOT EXISTS `confirmaciones` (
  `id_confirmacion` int(11) NOT NULL AUTO_INCREMENT,
  `id_libro` int(11) NOT NULL,
  `num_hoja` int(11) NOT NULL,
  `num_partida` int(11) NOT NULL,
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
  PRIMARY KEY (`id_confirmacion`),
  KEY `id_libro` (`id_libro`),
  KEY `id_libro_2` (`id_libro`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=63 ;

--
-- Dumping data for table `confirmaciones`
--

INSERT INTO `confirmaciones` (`id_confirmacion`, `id_libro`, `num_hoja`, `num_partida`, `nombre`, `padre`, `madre`, `fecha_confirmacion`, `fecha_bautismo`, `lugar_bautismo`, `padrino`, `madrina`, `presbitero`, `anio`) VALUES
(61, 7, 1, 5, 'JUAN JOSE PEREZ DE LA O', 'JOSE PEREZ HUACANO', 'PANCRACIA DE LA O Y U', '2012-12-21', '2012-06-12', 'EL CEÑIDOR', 'KIKURRINO WATSTREET', 'BOOKSTRAMP DE FORD', 'RATERO', '1990'),
(62, 7, 1, 6, 'KLJAS DLAKSJDLKAJD LKAJDLKASJDL', 'LKJSDLKJDSFLKJ SFLJDSLKFJDSLFK JL', 'DSLKFJ LKSDFJ LDS FJLKSDFJSKL', '2014-05-24', '2014-05-24', 'SDJLKADJ LJ LKSDJFLKSDFJ ', 'J DSLKFJ SDLKFJ LKJ LK', 'SFL JLSKDFJLKDSF JLK JLSJL', ' LKDJ LDKFJL', '1986');

-- --------------------------------------------------------

--
-- Table structure for table `libros`
--

CREATE TABLE IF NOT EXISTS `libros` (
  `id_libro` int(11) NOT NULL AUTO_INCREMENT,
  `id_categoria` int(11) DEFAULT NULL,
  `nombre_libro` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_libro`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Dumping data for table `libros`
--

INSERT INTO `libros` (`id_libro`, `id_categoria`, `nombre_libro`) VALUES
(1, 1, 'LIBRO 1'),
(3, 1, 'LIBRO 2'),
(7, 2, 'LIBRO 2'),
(8, 4, 'LIBRO 1'),
(9, 4, 'LIBRO 2'),
(11, 3, 'LIBRO 1'),
(12, 3, 'Libro 2');

-- --------------------------------------------------------

--
-- Table structure for table `matrimonios`
--

CREATE TABLE IF NOT EXISTS `matrimonios` (
  `id_matrimonio` int(11) NOT NULL AUTO_INCREMENT,
  `id_libro` int(11) NOT NULL,
  `num_hoja` int(11) NOT NULL,
  `num_partida` int(11) NOT NULL,
  `novio` varchar(100) NOT NULL,
  `novia` varchar(100) NOT NULL,
  `fecha_matrimonio` date NOT NULL,
  `lugar_celebracion` varchar(100) NOT NULL,
  `testigo1` varchar(100) NOT NULL,
  `testigo2` varchar(100) NOT NULL,
  `asistente` varchar(100) NOT NULL,
  `nota_marginal` varchar(100) NOT NULL,
  `anio` varchar(10) NOT NULL,
  PRIMARY KEY (`id_matrimonio`),
  KEY `id_libro` (`id_libro`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `matrimonios`
--

INSERT INTO `matrimonios` (`id_matrimonio`, `id_libro`, `num_hoja`, `num_partida`, `novio`, `novia`, `fecha_matrimonio`, `lugar_celebracion`, `testigo1`, `testigo2`, `asistente`, `nota_marginal`, `anio`) VALUES
(1, 8, 1, 1, 'JAVIER CALDERON CHAVEZ', 'MARIBEL TORRES', '2016-06-15', 'EL CEÑIDOR', 'ALFONSO CALDERON', 'TERESA CHAVEZ', 'ARISAI BOTELLO', '', '2014'),
(2, 8, 1, 2, 'KJ SDKJFHDSKJFH SJDF H', 'H DSKJFHSKJDF SD FSDKFH SKJD FHK', '2014-05-24', 'KJ SHFKJDSF HDSK FKJDSHF K', ' SHDFKJ SHK', ' HKSD HFKJ', 'H KJ HFK', '', '1991'),
(3, 9, 1, 3, 'ADSJLK', 'DSLKFJLKDSFJ', '2014-05-24', 'SDKLFJ SDLKF LKF ', 'KJDS FLKSDJ FL', ' LDS FJLKSF JLK', 'J LKDFJ LDSKJFLKSD', '', '2014'),
(4, 8, 1, 4, 'JAVIER CALDERON', 'MARIBEL TORRES', '2012-05-14', 'EL CEÑIDOR', 'NOSE QUIEN TESTIGO 1', 'NOSE QUIEN TESTIGO 2', 'ASD ASISTENTE', '', '2012'),
(5, 8, 1, 5, 'JAVIER', 'MARIBEL', '1991-11-24', 'CEÑIDOR EL', 'T1', 'T2', 'ASISTENTE', 'SE VOLVIERON A CASAR', '1988');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bautismos`
--
ALTER TABLE `bautismos`
  ADD CONSTRAINT `bautismos_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE;

--
-- Constraints for table `comuniones`
--
ALTER TABLE `comuniones`
  ADD CONSTRAINT `comuniones_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE;

--
-- Constraints for table `confirmaciones`
--
ALTER TABLE `confirmaciones`
  ADD CONSTRAINT `confirmaciones_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE;

--
-- Constraints for table `matrimonios`
--
ALTER TABLE `matrimonios`
  ADD CONSTRAINT `matrimonios_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
