/*
SQLyog Ultimate v8.32 
MySQL - 5.5.50 : Database - casedata
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`casedata` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `casedata`;

/*Table structure for table `case_list` */

DROP TABLE IF EXISTS `case_list`;

CREATE TABLE `case_list` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `case_name` varchar(200) DEFAULT NULL,
  `case_no` varchar(100) NOT NULL,
  `case_date` datetime DEFAULT NULL,
  `author` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `case_no` (`case_no`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

/*Data for the table `case_list` */

/*Table structure for table `excel_list` */

DROP TABLE IF EXISTS `excel_list`;

CREATE TABLE `excel_list` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `file_name` varchar(200) DEFAULT NULL,
  `case_no` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`),
  KEY `case_no` (`case_no`),
  CONSTRAINT `excel_list_ibfk_1` FOREIGN KEY (`case_no`) REFERENCES `case_list` (`case_no`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8;

/*Data for the table `excel_list` */

/*Table structure for table `field_list` */

DROP TABLE IF EXISTS `field_list`;

CREATE TABLE `field_list` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `field` varchar(100) DEFAULT NULL,
  `sheet_id` int(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `sheet_id` (`sheet_id`),
  CONSTRAINT `field_list_ibfk_1` FOREIGN KEY (`sheet_id`) REFERENCES `sheet_list` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=376 DEFAULT CHARSET=utf8;

/*Data for the table `field_list` */

/*Table structure for table `rule_detail` */

DROP TABLE IF EXISTS `rule_detail`;

CREATE TABLE `rule_detail` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `case_no` varchar(100) DEFAULT NULL,
  `excel` varchar(200) DEFAULT NULL,
  `sheet` varchar(100) DEFAULT NULL,
  `field` varchar(100) DEFAULT NULL,
  `rule_id` int(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `rule_id` (`rule_id`),
  CONSTRAINT `rule_detail_ibfk_1` FOREIGN KEY (`rule_id`) REFERENCES `rule_list` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

/*Data for the table `rule_detail` */

/*Table structure for table `rule_list` */

DROP TABLE IF EXISTS `rule_list`;

CREATE TABLE `rule_list` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(200) DEFAULT NULL,
  `type` int(11) NOT NULL,
  `excel_id` int(20) DEFAULT NULL,
  `case_no` varchar(100) DEFAULT NULL,
  `excel` varchar(200) DEFAULT NULL,
  `sheet` varchar(100) DEFAULT NULL,
  `field` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`),
  KEY `excel_id` (`excel_id`),
  CONSTRAINT `rule_list_ibfk_1` FOREIGN KEY (`excel_id`) REFERENCES `excel_list` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

/*Data for the table `rule_list` */

/*Table structure for table `sheet_list` */

DROP TABLE IF EXISTS `sheet_list`;

CREATE TABLE `sheet_list` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `sheet` varchar(100) DEFAULT NULL,
  `excel_id` int(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`),
  KEY `excel_id` (`excel_id`),
  CONSTRAINT `sheet_list_ibfk_1` FOREIGN KEY (`excel_id`) REFERENCES `excel_list` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=139 DEFAULT CHARSET=utf8;

/*Data for the table `sheet_list` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
