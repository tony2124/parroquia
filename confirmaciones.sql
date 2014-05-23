-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: May 23, 2014 at 07:08 PM
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
  `padrino` varchar(200) NOT NULL,
  `madrina` varchar(200) NOT NULL,
  `fecha_bautismo` date NOT NULL,
  `fecha_confirmacion` date NOT NULL,
  `lugar_bautismo` varchar(100) NOT NULL,
  `ministro` varchar(100) NOT NULL,
  `anio` varchar(4) NOT NULL,
  PRIMARY KEY (`id_confirmacion`),
  KEY `id_libro` (`id_libro`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=57 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
