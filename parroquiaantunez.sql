-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 31-05-2014 a las 04:20:39
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
  KEY `id_libro_2` (`id_libro`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=27 ;

--
-- Volcado de datos para la tabla `bautismos`
--

INSERT INTO `bautismos` (`id_bautismo`, `id_libro`, `num_hoja`, `num_partida`, `nombre`, `padre`, `madre`, `fecha_nac`, `lugar_nac`, `fecha_bautismo`, `padrino`, `madrina`, `presbitero`, `anotacion`, `anio`, `bis`) VALUES
(4, 1, 1, '1', 'FRANCISCO JAVIER CALDERON CHAVEZ', 'MARIO CALDERON MENDEZ', 'TERESA CHAVEZ HERNANDEZ', '1991-11-24', 'NUEVA ITALIA MICHOACAN', '1992-11-24', 'SERGIO PARDO', 'VENEDA CHAVEZ', 'NO ME ACUERDO DEL PADRE', 'NO RECUERDA EL PADRE EN ANOTACIONES', '1992', 0),
(5, 1, 1, '2', 'AMNDMB', 'NBANMSDBN', 'NNMSBNAM', '2014-05-26', 'NABSDNDSABDN', '2014-05-26', 'MNANMSDBN', 'MNBNASDBN', 'BNMASBNDBSN', 'MNNMABSDNMSABD', '2014', 0),
(6, 3, 1, '3', 'JUAN PEREZ MOTA A', 'JONATHAN PEREZ A', 'MARIA MOTA A ', '1999-11-17', 'APATZINGANA', '2000-02-17', 'PADRINO A', 'MADRINA A', 'PRESBITEROA', 'NO ES VERDAD QA', '2000', 0),
(7, 1, 1, '4', 'JESUS', 'DESCONOCIDO', 'DESCONOCIDA', '2014-05-26', 'APATZINGAN', '2014-05-26', 'JOSE', 'JOSEGA', 'JUAN', 'NADA', '', 0),
(8, 3, 1, '5', 'ADAJSDKLSADJKKKKKKKKKKHJJJJJ', 'LKJASLKDJASKLDJ', 'LKJLKASJDKASLDJ', '2014-05-26', 'KASJDKLASDKLSAJ', '2014-05-26', 'KJAKLSDJSAKLDJ', 'KJALKSDJSALKDJ', 'KLJALKSD', '', '2014', 0),
(9, 3, 1, '6', 'JESUS SANCHEZ SOTO', 'JESUS', 'JOSE', '2014-05-26', 'APATZINGAN', '2014-05-26', 'JUAN', 'PEDRO', 'PABLO', '', '2014', 0),
(10, 3, 1, '7', 'ALFONSO CALDERON CHAVEZ', 'MARIO CALDERON MENDEZ', 'TERESA CHAVEZ HERNANDEZ', '2014-05-26', 'APATZINGAN', '2014-05-26', 'REYES', 'SILVIA', 'PABLO', '', '1991', 0),
(11, 3, 1, '8', 'ASDHKJJ', 'HJAHDJHSJHKA', 'JASHDJSAHD', '2014-05-26', 'AKJSHDJKSAHD', '2014-05-26', 'AJKSDHJKSAD', 'JAJKSDHJKASHD', 'JKHASKJDHJKSAD', '', '2014', 0),
(12, 3, 1, '9', 'JAKDHSAJKHJ', 'HJKAHSDJKH', 'JKHAJKSDHJKSA', '2014-05-26', 'JKHASDJKHSAJKDH', '2014-05-26', 'JHKJASHDJKSAHKJ', 'HKJASHDJKSAHD', 'KJAKJHSDJKSAHD', '', '2014', 0),
(13, 3, 1, '10', 'JESUS CHAVEZ', 'JESUS', 'IRENE', '2014-05-26', 'EL CEÑIDOR', '2014-05-26', 'JUA', 'PEDRO', 'JOSEFA', '', '2014', 0),
(14, 3, 2, '11', 'ALKDASKDJKASKLD', 'KJASLKDJASLKDJ', 'KJKALSDJAKSLDJ', '2014-05-26', 'SKDALKJASKLDJKL', '2014-05-26', 'KJASKDJASKLDJAS', 'KASSJDKLASJDKL', 'DOPAIDSA', 'AKDASKLDJ', '2014', 0),
(15, 3, 2, '12', 'MARISOL SERNA GONZALEZ', 'ASJJDSAKJDHJK', 'KJASDJKASHDJKH', '2014-05-26', 'JHASDKJSADHKJ', '2014-05-26', 'KJASJKDHASJKDHSAJK', 'KJHASJKDHSAKJDH', 'KJHASKJDASJDASDKJASH', '', '2014', 0),
(16, 3, 1, '9BIS', 'LÑFKDLSÑKF', 'LKLKDLASDKL', 'KLALKDKLSAJKDL', '2014-05-28', 'ASLKJDKLSADJKL', '2014-05-28', 'KJASKLJDKLSJD', 'LKJALKSJDLKASJD', 'LKJAKLSDJKLASJD', 'KADJASKLDJKKL', '2014', 1),
(17, 3, 1, '10', 'LKSFJLKDSFJ', 'JKJDFKLSJADKL', 'KJALKDJAKSLDJ', '2014-05-28', 'LKJDKLFJASKLD', '2014-05-28', 'KLJDLKJKAL', 'KLADFKLJAS', 'LKALKDJKASD', '', '2014', 0),
(18, 3, 2, '11', 'ALKDSAKLDJAKL', 'LKASLKDLKSAJ', 'LKLKASJDKLJAS', '2014-05-28', 'LKJDKLDASKLDJ', '2014-05-28', 'LKJASLKDJSAKL', 'KLJLKASJDKLASJ', 'LKJALKSJDKASL', 'LJKLASJDLKASJD', '2014', 0),
(19, 3, 2, '11BIS', 'ZLKDCKKLLKKL', 'LKSDKLFSKJFKJSDKJ', 'LKSDLFDSKFK', '2014-05-28', 'LKDFJKDSKLFALK', '2014-05-28', 'LKAJLKLADKSKL', 'KLAKDJKASKDJKL', 'KAJDKLSADJK', '', '2014', 1),
(20, 3, 2, '12', 'SDLKFKDFK', 'KLSDLKFALKLK', 'LKSDKLFKJA', '2014-05-28', 'KLSDFLKJSL', '2014-05-28', 'LKJKALJFKLJ', 'JKSLDJFKLAJ', 'KLJKLSJDKLSAJD', '', '2014', 0),
(21, 3, 2, '13', 'WFPEQOP', 'OOEFO', 'OOOSDFO', '2014-05-28', 'ODFO', '2014-05-28', 'OPADO', 'OADO', 'OAOPDOAA', '', '2014', 0),
(22, 3, 2, '14', 'ASKJDHSAKJH', 'HJKASHDJKASH', 'JJKAHSDJKHJKHJKAH', '2014-05-29', 'JHASJKDH', '2014-05-29', 'JHJKASHDJK', 'HJKHAJKSDHJK', 'HJKAHSJKDSA', '', '2014', 0),
(23, 3, 2, '15', 'LKDSKFDSKJJKKJKJKJJJJJ', 'KLASJDLKASJKL', 'JKLASJDKL', '2014-05-29', 'KLASDLKJASDLJ', '2014-05-29', 'KJKASLJDKLSAJDLK', 'JKLASJDKLASJDKLJ', 'KLJASKLDJSKALDJKASL', '', '2014', 0),
(24, 3, 2, '16', 'HHHHHHHHHHHHHHHH', 'HHHHHHHHHHHHHHHHHH', 'HHHHHHHHHHHHHH', '2014-05-30', 'HHHHHHHHHHHHHHHHHH', '2014-05-30', 'HHHHHHHHHHHHHHHHHHH', 'HHHHHHHHHHHHHHHHHH', 'HHHHHHHHHHHHHHHHHHHH', '', '2014', 0),
(25, 3, 2, '17', 'K.-----------------', '--------------', '-------------', '2014-05-30', '------------------', '2014-05-30', '-------------------', '--------------------', '--------------------', '', '2014', 0),
(26, 3, 2, '18', '--------------------------', '----------------------', '----------------------------', '2014-05-30', '----------------------', '2014-05-30', '------------------', '-------------------------', '-----------------------', '', '2014', 0);

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
-- Estructura de tabla para la tabla `comuniones`
--

CREATE TABLE IF NOT EXISTS `comuniones` (
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
  KEY `id_libro` (`id_libro`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=17 ;

--
-- Volcado de datos para la tabla `comuniones`
--

INSERT INTO `comuniones` (`id_comunion`, `id_libro`, `num_hoja`, `num_partida`, `nombre`, `padre`, `madre`, `fecha_comunion`, `fecha_bautismo`, `lugar_bautismo`, `padrino`, `madrina`, `anio`, `bis`) VALUES
(1, 11, 1, '1', 'FRANCISCO JAVIER CALDERON CHAVEZ', 'MARIO CALDERON MENDEZ', 'TERESA CHAVEZ HERNANDEZ', '1997-12-12', '1991-11-24', 'EL CEÑIDOR MICHOACAN', 'SERGIO PARDO MENERA', 'VENEDA CHAVEZ', '2014', 0),
(2, 12, 1, '2', 'WATASHI NAKATA NO', 'ZOKKA TAKOMU', 'NIOJO AKATA ', '1997-12-12', '1901-11-24', 'ANTUNEZ MICHOACAN', 'AANG TORILLA MA', 'KATARA UZUMAKI', '1997', 0),
(3, 12, 1, '3', 'ASD ASDSA', 'SDFSD', 'FDSF SF', '2014-05-25', '1991-12-19', 'SDFSDF', 'SDFSD', 'FDSF', '1997', 0),
(4, 12, 1, '4', 'FYG', 'GFDFQ', 'YGYT', '2014-05-25', '2014-05-25', 'UYUYT', '1TYF', 'YGF', '', 0),
(5, 12, 1, '5', 'HJG', 'HJG', 'JHG', '2014-05-25', '2014-05-25', 'JHGJ', 'HGJ', 'HGJH', '1997', 0),
(6, 12, 1, '6', 'K', 'KJH', 'KJHKJ', '2014-05-25', '2014-05-25', 'HKJ', 'HKJ', 'HJK', '1997', 0),
(7, 12, 1, '7', 'POI', 'OPII', 'IOP', '2014-05-25', '2014-05-25', 'POIPOI', 'POI', 'RTER', '1997', 0),
(8, 12, 1, '8', 'TRE', 'TR', 'RERER', '2014-05-25', '2014-05-25', 'RYT', 'RYTR', 'YT', '1997', 0),
(9, 12, 1, '9', 'TR', 'RT', 'RT', '2014-05-25', '2014-05-25', 'T', 'TRE', 'TR', '1997', 0),
(10, 12, 1, '10', 'T', 'TR', 'TYR', '2014-05-25', '2014-05-25', 'R', 'YTR', 'YT', '1997', 0),
(11, 11, 2, '11', 'DFD', 'ASD', 'ADDDDD DSDASD', '2014-05-25', '2014-05-25', 'FGD', 'FGDGFD', 'GFDGFD', '2013', 0),
(12, 12, 2, '12', 'ALFONSO CALDERON CHAVEZ', 'MARIO CALDERON', 'TERESA CHAVEZ', '2014-05-27', '2014-05-27', 'EL CEÑIDOR', 'FELIIPE CALDERON', 'ESTHER GORDILLO', '2014', 0),
(13, 12, 2, '13', 'KKKKKKKK', 'KAKDKLASDKLSADK', 'KJKASJDKLASJD', '2014-05-27', '2014-05-27', 'KADKASJDSA', 'ASDASDJASKLDJASASDASLD', 'KJAKLSDASLKDJ', '2014', 0),
(14, 12, 2, '12', 'DKKFDJSKLJ', 'JKLSDJFKLJ', 'KLJSKDLJ', '2014-05-29', '2014-05-29', 'ASDSKAJDKL', 'LKASJLKDJASLK', 'LKJSDJSALKDJASLKDJ', '2014', 0),
(15, 12, 2, '13', 'HJKDSDASJH', 'JKHKAJSDHASKJH', 'QKJHAKSJDHKJAS', '2014-05-30', '2014-05-30', 'KJAHSDKJSAHD', 'KJHAKJSDHSKJAH', 'KJHAKSJHDAS', '2014', 0),
(16, 12, 2, '14', 'KXJHKJHKJHKJHKJHKJ', 'HJHKJHJKHJKHKJHKJ', 'HHJHJHJKKJH', '2014-05-30', '2014-05-30', 'KJHJKHHKJHKJHJK', 'HJHJHJKJKHHKJHJK', 'HKJHJKHJKHJKJKH', '2014', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `confirmaciones`
--

CREATE TABLE IF NOT EXISTS `confirmaciones` (
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
  KEY `id_libro_2` (`id_libro`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Volcado de datos para la tabla `confirmaciones`
--

INSERT INTO `confirmaciones` (`id_confirmacion`, `id_libro`, `num_hoja`, `num_partida`, `nombre`, `padre`, `madre`, `fecha_confirmacion`, `fecha_bautismo`, `lugar_bautismo`, `padrino`, `madrina`, `presbitero`, `anio`, `bis`) VALUES
(1, 7, 1, '1', '', '', '', '2014-05-26', '2014-05-26', '', '', '', '', '', 0),
(2, 7, 1, '2', 'ALFONSO CALDERON CHAVEZ', 'MARIO CALDEROIN', 'TERESA CHAVEZ', '2014-05-26', '2014-05-26', 'APATZINGAN', 'LEJANA', 'LEJANA', 'ASKDSADKJLL', '2014', 0),
(3, 7, 1, '3', 'KKKKLLLLLLLLLLL', 'LKASJDKLASJDLLLLLLLL', 'LLLLLLLLLLLLLL', '2014-05-26', '2014-05-26', 'LLLLLLLLLLLLLLLL', 'LLLLLLLLLLLLLLLLL', 'LLLLLLLLLLLLLLL', 'LLLLLLLLLLLLLLL', '2014', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `informacion`
--

CREATE TABLE IF NOT EXISTS `informacion` (
  `nombre_parroquia` varchar(100) NOT NULL,
  `nombre_parroco` varchar(100) NOT NULL,
  `ubicacion_parroquia` varchar(100) NOT NULL,
  `ubicacion_carpeta` varchar(100) NOT NULL,
  `contrasena` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `informacion`
--

INSERT INTO `informacion` (`nombre_parroquia`, `nombre_parroco`, `ubicacion_parroquia`, `ubicacion_carpeta`, `contrasena`) VALUES
('Ntra. Sra. de Gpe.', 'Antonio Mendoza', 'Antúnez, Michoacán', 'c:/DOCsParroquia', '4255925238');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `libros`
--

CREATE TABLE IF NOT EXISTS `libros` (
  `id_libro` int(11) NOT NULL AUTO_INCREMENT,
  `id_categoria` int(11) DEFAULT NULL,
  `nombre_libro` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_libro`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Volcado de datos para la tabla `libros`
--

INSERT INTO `libros` (`id_libro`, `id_categoria`, `nombre_libro`) VALUES
(1, 1, 'LIBRO 1'),
(3, 1, 'LIBRO 2'),
(7, 2, 'LIBRO 2'),
(8, 4, 'LIBRO 1'),
(9, 4, 'LIBRO 2'),
(11, 3, 'LIBRO 1'),
(12, 3, 'LIBRO 2');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `matrimonios`
--

CREATE TABLE IF NOT EXISTS `matrimonios` (
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
  KEY `id_libro` (`id_libro`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=12 ;

--
-- Volcado de datos para la tabla `matrimonios`
--

INSERT INTO `matrimonios` (`id_matrimonio`, `id_libro`, `num_hoja`, `num_partida`, `novio`, `novia`, `fecha_matrimonio`, `lugar_celebracion`, `testigo1`, `testigo2`, `asistente`, `nota_marginal`, `anio`, `bis`) VALUES
(1, 8, 1, '1', 'JAVIER CALDERON CHAVEZ', 'MARIBEL TORRES SAUCEDO', '2016-06-15', 'EL CEÑIDOR', 'ALFONSO CALDERON', 'TERESA CHAVEZ', 'ARISAI BOTELLO', '', '2014', 0),
(2, 8, 1, '2', 'KJ SDKJFHDSKJFH SJDF H', 'H DSKJFHSKJDF SD FSDKFH SKJD FHK', '2014-05-24', 'KJ SHFKJDSF HDSK FKJDSHF K', ' SHDFKJ SHK', ' HKSD HFKJ', 'H KJ HFK', '', '1991', 0),
(3, 9, 1, '3', 'LKADKLASJDKLSAJDK', 'KLJAKLSDJSAKLDJ', '2014-05-27', 'KLASDLKJASKDLJ', 'KLJASLKDJASKDL', 'LKJAKLSDJSALK', 'LKJAKLSJDKSLAD', '', '', 0),
(4, 8, 1, '4', 'JAVIER CALDERON', 'MARIBEL TORRES', '2012-05-14', 'EL CEÑIDOR', 'NOSE QUIEN TESTIGO 1', 'NOSE QUIEN TESTIGO 2', 'ASD ASISTENTE', '', '2012', 0),
(5, 8, 1, '5', 'JAVIER', 'MARIBEL', '1991-11-24', 'CEÑIDOR EL', 'T1', 'T2', 'ASISTENTE', 'SE VOLVIERON A CASAR', '1988', 0),
(6, 9, 1, '2', 'ALFONSO CALDERON', 'JUANA', '2014-05-30', 'EL CEÑIDOR', 'ANTONIO', 'ANTONIA', 'ASLKDSALKDJ', 'ASLKDSALKD ASJDLKASJD KASJDSJADLSJK', '2014', 0),
(7, 9, 1, '2BIS', 'LKASDJKASLJK', 'LJKLASDJKL', '2014-05-30', 'KLAJSDLKSAJ', 'KLJALKSDJLK', 'LKJALKSJDLKAS', 'LKJALKSJDLKSAJ', 'LKJASLKDJSKALD', '2014', 1),
(8, 9, 1, '3', 'IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII', 'KLJASDKJSAJD', '2014-05-30', 'JKHASJKDHASKJ', 'JHSAJKDHKJAH', 'JKHAKJSDHASKJH', 'JHAJSKDHKJASH', '', '2014', 0),
(9, 9, 1, '4', 'DSKJH', 'KJASJKDJHK', '2014-05-30', 'AJSKHDASJKDH', 'JHASKJDHKASJH', 'JHAKJSDHJK', 'HJKAHSDJHASJDK', '', '2014', 0),
(10, 9, 1, '5', 'OIWOIIOIO', 'II', '2014-05-30', 'KJASDKJHHJK', 'IUOUIOIUOIUOWASD', 'JKASJDHASJKDJH', 'ASJDHKASKJDAKJSHKJ', '', '2014', 0),
(11, 9, 1, '6', 'SAJJK', 'JKLJ', '2014-05-30', 'LKJLKJL', 'KJLKJ', 'LKJLKJ', 'LKJLKJ', 'LKJLKJ', '2014', 0);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `bautismos`
--
ALTER TABLE `bautismos`
  ADD CONSTRAINT `bautismos_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `comuniones`
--
ALTER TABLE `comuniones`
  ADD CONSTRAINT `comuniones_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE;

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
