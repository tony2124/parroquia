-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 26-05-2014 a las 00:12:44
-- Versión del servidor: 5.6.12-log
-- Versión de PHP: 5.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `parroquiaantunez`
--
CREATE DATABASE IF NOT EXISTS `parroquiaantunez` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `parroquiaantunez`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bautismos`
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Volcado de datos para la tabla `bautismos`
--

INSERT INTO `bautismos` (`id_bautismo`, `id_libro`, `num_hoja`, `num_partida`, `nombre`, `padre`, `madre`, `fecha_nac`, `lugar_nac`, `fecha_bautismo`, `padrino`, `madrina`, `presbitero`, `anotacion`, `anio`) VALUES
(1, 1, 1, 3, 'JAVIER CALDERO', 'NO SE ', 'NO SE 2', '2014-05-20', 'NUEVA ITALIA', '2014-05-20', 'PADRINO', 'NO SE DE DONDE MADRINA', 'PRESBITERO', 'QUE CHIDO TODO', '1988'),
(2, 1, 1, 2, 'ALFONSO CALDERON CHAVEZ', 'MARIO CALDERON MENDEZ', 'TERESA CHAVEZ HERNANDEZ', '1990-06-04', 'APATZINGAN', '1991-04-10', 'REYES SANCHEZ PONCE', 'SILVIA VERDUZCO', 'RUBEN GARCIA', '', '1991');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categorias`
--

CREATE TABLE IF NOT EXISTS `categorias` (
  `id_categoria` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_categoria` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_categoria`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Volcado de datos para la tabla `categorias`
--

INSERT INTO `categorias` (`id_categoria`, `nombre_categoria`) VALUES
(1, 'BAUTISMO'),
(2, 'CONFIRMACIÓN'),
(3, 'PRIMERA COMUNION'),
(4, 'MATRIMONIO');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `confirmaciones`
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
-- Volcado de datos para la tabla `confirmaciones`
--

INSERT INTO `confirmaciones` (`id_confirmacion`, `id_libro`, `num_hoja`, `num_partida`, `nombre`, `padre`, `madre`, `fecha_confirmacion`, `fecha_bautismo`, `lugar_bautismo`, `padrino`, `madrina`, `presbitero`, `anio`) VALUES
(61, 7, 1, 5, 'JUAN JOSE PEREZ DE LA O', 'JOSE PEREZ HUACANO', 'PANCRACIA DE LA O Y U', '2012-12-21', '2012-06-12', 'EL CEÑIDOR', 'KIKURRINO WATSTREET', 'BOOKSTRAMP DE FORD', 'RATERO', '1990'),
(62, 7, 1, 6, 'KLJAS DLAKSJDLKAJD LKAJDLKASJDL', 'LKJSDLKJDSFLKJ SFLJDSLKFJDSLFK JL', 'DSLKFJ LKSDFJ LDS FJLKSDFJSKL', '2014-05-24', '2014-05-24', 'SDJLKADJ LJ LKSDJFLKSDFJ ', 'J DSLKFJ SDLKFJ LKJ LK', 'SFL JLSKDFJLKDSF JLK JLSJL', ' LKDJ LDKFJL', '1986');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `libros`
--

CREATE TABLE IF NOT EXISTS `libros` (
  `id_libro` int(11) NOT NULL AUTO_INCREMENT,
  `id_categoria` int(11) DEFAULT NULL,
  `nombre_libro` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_libro`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Volcado de datos para la tabla `libros`
--

INSERT INTO `libros` (`id_libro`, `id_categoria`, `nombre_libro`) VALUES
(1, 1, 'LIBRO 1'),
(3, 1, 'LIBRO 2'),
(7, 2, 'LIBRO 2'),
(8, 4, 'LIBRO 1'),
(9, 4, 'LIBRO 2');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `matrimonios`
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Volcado de datos para la tabla `matrimonios`
--

INSERT INTO `matrimonios` (`id_matrimonio`, `id_libro`, `num_hoja`, `num_partida`, `novio`, `novia`, `fecha_matrimonio`, `lugar_celebracion`, `testigo1`, `testigo2`, `asistente`, `nota_marginal`, `anio`) VALUES
(1, 8, 1, 1, 'JAVIER CALDERON CHAVEZ', 'MARIBEL TORRES', '2016-06-15', 'EL CEÑIDOR', 'ALFONSO CALDERON', 'TERESA CHAVEZ', 'ARISAI BOTELLO', '', '2014'),
(2, 8, 1, 2, 'KJ SDKJFHDSKJFH SJDF H', 'H DSKJFHSKJDF SD FSDKFH SKJD FHK', '2014-05-24', 'KJ SHFKJDSF HDSK FKJDSHF K', ' SHDFKJ SHK', ' HKSD HFKJ', 'H KJ HFK', '', '1991'),
(3, 9, 1, 3, 'ADSJLK', 'DSLKFJLKDSFJ', '2014-05-24', 'SDKLFJ SDLKF LKF ', 'KJDS FLKSDJ FL', ' LDS FJLKSF JLK', 'J LKDFJ LDSKJFLKSD', '', '2014');

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `bautismos`
--
ALTER TABLE `bautismos`
  ADD CONSTRAINT `bautismos_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `confirmaciones`
--
ALTER TABLE `confirmaciones`
  ADD CONSTRAINT `confirmaciones_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `matrimonios`
--
ALTER TABLE `matrimonios`
  ADD CONSTRAINT `matrimonios_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
