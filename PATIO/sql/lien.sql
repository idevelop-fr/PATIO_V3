-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Ven 09 Novembre 2018 à 08:48
-- Version du serveur :  5.7.11
-- Version de PHP :  7.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `patio`
--

-- --------------------------------------------------------

--
-- Structure de la table `lien`
--

DROP TABLE IF EXISTS `lien`;
CREATE TABLE `lien` (
  `id` int(11) NOT NULL,
  `element0_type` int(11) NOT NULL,
  `element0_code` varchar(100) COLLATE latin1_general_ci DEFAULT NULL,
  `element0_id` int(11) NOT NULL,
  `element1_type` int(11) NOT NULL,
  `element1_code` varchar(100) COLLATE latin1_general_ci DEFAULT NULL,
  `element1_id` int(11) NOT NULL,
  `element2_type` int(11) NOT NULL,
  `element2_code` varchar(100) COLLATE latin1_general_ci DEFAULT NULL,
  `element2_id` int(11) NOT NULL,
  `ordre` smallint(6) NOT NULL,
  `complement` varchar(100) COLLATE latin1_general_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Index pour les tables exportées
--

--
-- Index pour la table `lien`
--
ALTER TABLE `lien`
  ADD PRIMARY KEY (`id`),
  ADD KEY `element0_type` (`element0_type`),
  ADD KEY `id` (`id`),
  ADD KEY `element0_id` (`element0_id`),
  ADD KEY `element0_code` (`element0_code`),
  ADD KEY `element1_code` (`element1_code`),
  ADD KEY `element1_type` (`element1_type`),
  ADD KEY `element1_id` (`element1_id`),
  ADD KEY `element2_type` (`element2_type`),
  ADD KEY `element2_code` (`element2_code`),
  ADD KEY `ordre` (`ordre`),
  ADD KEY `element2_id` (`element2_id`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `lien`
--
ALTER TABLE `lien`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
