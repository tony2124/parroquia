-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jun 10, 2014 at 10:51 PM
-- Server version: 5.6.17-log
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
-- Table structure for table `coordenadas`
--

CREATE TABLE IF NOT EXISTS `coordenadas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoria` int(11) NOT NULL,
  `formato` int(11) NOT NULL,
  `x` int(11) NOT NULL,
  `y` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `categoria` (`categoria`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `coordenadas`
--

INSERT INTO `coordenadas` (`id`, `categoria`, `formato`, `x`, `y`) VALUES
(1, 1, 1, 0, 0),
(2, 2, 1, 0, 0),
(3, 3, 1, 0, 0),
(4, 4, 1, 2, 2),
(5, 1, 2, 0, 2);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `coordenadas`
--
ALTER TABLE `coordenadas`
  ADD CONSTRAINT `coordenadas_ibfk_1` FOREIGN KEY (`categoria`) REFERENCES `categorias` (`id_categoria`) ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
