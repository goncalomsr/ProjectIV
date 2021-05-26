-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 26-Maio-2021 às 12:54
-- Versão do servidor: 10.4.17-MariaDB
-- versão do PHP: 8.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `annarrjord`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `finaleoption`
--

CREATE TABLE `finaleoption` (
  `user_id` int(11) NOT NULL,
  `vote_time` timestamp NOT NULL DEFAULT current_timestamp(),
  `option_selected` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `finaleoption`
--

INSERT INTO `finaleoption` (`user_id`, `vote_time`, `option_selected`) VALUES
(1, '2021-04-29 09:24:08', 0),
(2, '2021-04-29 09:24:55', 0),
(3, '2021-04-29 11:23:40', 1),
(4, '2021-04-29 11:36:29', 1),
(5, '2021-04-30 11:30:31', 1),
(6, '2021-04-30 11:40:40', 1);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `finaleoption`
--
ALTER TABLE `finaleoption`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `finaleoption`
--
ALTER TABLE `finaleoption`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
