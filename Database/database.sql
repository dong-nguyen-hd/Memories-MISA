-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.5.10-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for emis
CREATE DATABASE IF NOT EXISTS `emis` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `emis`;

-- Dumping structure for table emis.fee
CREATE TABLE IF NOT EXISTS `fee` (
  `FeeId` char(36) NOT NULL DEFAULT '' COMMENT 'Kh?a ch?nh',
  `FeeName` varchar(255) NOT NULL DEFAULT '' COMMENT 'T?n kho?n thu',
  `FeeGroupId` char(36) DEFAULT NULL COMMENT 'Kh?a ngo?i nh?m kho?n thu',
  `FeeRangeId` char(36) DEFAULT NULL COMMENT 'Kh?a ch?nh c?a ph?m vi thu',
  `UnitFeeId` char(36) NOT NULL COMMENT '?on v? m?c thu',
  `TurnFee` int(11) NOT NULL COMMENT 'K? thu(0-thang, 1-Quy, 2-Hoc ky,3- Nam hoc)',
  `Discount` bit(1) NOT NULL DEFAULT b'0' COMMENT '?p d?ng mi?n gi?m',
  `AmountOfFee` double DEFAULT NULL COMMENT 'M?c thu#',
  `AllowExportLicense` bit(1) NOT NULL DEFAULT b'0' COMMENT 'Cho ph?p xu?t ch?ng t?',
  `FeeRequired` bit(1) NOT NULL DEFAULT b'0' COMMENT 'Kho?n thu bartw bu?c',
  `AllowReturn` bit(1) NOT NULL DEFAULT b'0' COMMENT 'Cho ph?p ho?n tr?',
  `AllowExportBill` bit(1) NOT NULL DEFAULT b'0' COMMENT 'Cho ph?p xu?t h?a don#',
  `FeePrivate` bit(1) NOT NULL DEFAULT b'0' COMMENT 'Thu n?i b?',
  `TypeRegistion` bit(1) NOT NULL DEFAULT b'0' COMMENT 'Ph?n lo?i dang k?',
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` varchar(100) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `Quality` int(11) DEFAULT NULL COMMENT 'T?nh ch?t',
  `Follow` bit(1) DEFAULT NULL COMMENT 'Trạng thái theo dõi (true = ngừng theo dõi, flase đang theo dõi)',
  `Important` bit(1) NOT NULL DEFAULT b'0' COMMENT 'Đánh dấu bản ghi không được phép xóa',
  PRIMARY KEY (`FeeId`),
  UNIQUE KEY `UK_Fee_FeeId` (`FeeId`),
  UNIQUE KEY `UK_Fee_FeeName` (`FeeName`),
  KEY `IDX_Fee_FeeRangeId` (`FeeRangeId`),
  KEY `IDX_Fee_UnitFeeId` (`UnitFeeId`),
  CONSTRAINT `FK_Fee_FeeRangeId` FOREIGN KEY (`FeeRangeId`) REFERENCES `feerange` (`FeeRangeId`) ON DELETE NO ACTION,
  CONSTRAINT `FK_Fee_UnitFeeId` FOREIGN KEY (`UnitFeeId`) REFERENCES `unitfee` (`UnitFeeId`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=434 COMMENT='B?ng d? li?u kho?n thu';

-- Dumping data for table emis.fee: ~124 rows (approximately)
/*!40000 ALTER TABLE `fee` DISABLE KEYS */;
INSERT INTO `fee` (`FeeId`, `FeeName`, `FeeGroupId`, `FeeRangeId`, `UnitFeeId`, `TurnFee`, `Discount`, `AmountOfFee`, `AllowExportLicense`, `FeeRequired`, `AllowReturn`, `AllowExportBill`, `FeePrivate`, `TypeRegistion`, `CreatedDate`, `CreatedBy`, `ModifiedDate`, `Quality`, `Follow`, `Important`) VALUES
	('0783853f-58fa-4c4a-a193-70a1878caa15', 'test312', '39446ba3-3071-7af6-a5a9-deaf32c96293', '4f610a3d-21c1-4b2b-c4fe-7f9a08424f7b', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'1', 3212121, b'1', b'1', b'1', b'1', b'1', b'1', '2021-06-20 02:24:38', 'NDDONG', NULL, 2, b'1', b'0'),
	('0c3ef207-d82b-4258-8290-3b633b2cd798', 'Nguyễn Duy Đông', NULL, NULL, '2b031b59-5276-589c-9d75-2a7ae1c799c8', 0, b'1', 0, b'1', b'1', b'1', b'1', b'1', b'1', '2021-06-15 19:15:06', 'NDDONG', NULL, 0, b'1', b'0'),
	('11452b0c-768e-5ff7-0d63-eeb1d8ed8cef', 'Tiền ăn bán trú', '71952621-23c8-61d2-d0eb-e423f1575e00', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'0', 100000, b'0', b'0', b'1', b'1', b'0', b'1', '2011-03-11 18:37:16', 'Adolph Francisco', '1984-07-31 00:31:37', 0, b'1', b'0'),
	('1152da18-24d8-65b6-0380-e8e2a817c80e', 'Bảo hiểm xã hội', '447816de-6069-15bf-de3d-c9e9e9038fe2', '4f610a3d-21c1-4b2b-c4fe-7f9a08424f7b', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'0', 1000000, b'1', b'0', b'1', b'0', b'0', b'0', '1997-10-08 13:04:08', 'Shonda Leake', '1970-01-01 00:05:07', 1, b'0', b'0'),
	('11f7089b-33e6-371a-f817-7000f455f3d5', 'Học nâng cao kỳ 1', '71952621-23c8-61d2-d0eb-e423f1575e00', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 3, b'1', 440000, b'0', b'1', b'0', b'0', b'0', b'1', '2007-07-01 14:15:33', 'Delcie Abney', '1970-01-01 02:09:09', 0, b'1', b'0'),
	('124b4a06-7d39-6835-0980-e8e2a817c80e', 'Sữa học đường tháng 4', '39446ba3-3071-7af6-a5a9-deaf32c96293', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 0, b'0', 2060000, b'1', b'0', b'1', b'1', b'1', b'0', '2007-05-18 03:51:37', 'Graham Alger', NULL, 1, b'0', b'0'),
	('13fc3540-52b5-3489-1163-eeb1d8ed8cef', 'Tiền ăn bán chú tháng 10', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 2, b'0', 1460000, b'0', b'0', b'0', b'1', b'0', b'0', '1970-01-01 00:55:33', 'Abram Fenton', '2015-02-11 03:35:04', 0, b'0', b'0'),
	('141eea25-7b62-62de-8832-6a1673ffca7c', 'Tiền ăn bán chú tháng 4', '447816de-6069-15bf-de3d-c9e9e9038fe2', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'0', 2040000, b'0', b'0', b'0', b'1', b'0', b'0', NULL, NULL, '1970-12-22 15:34:24', 0, b'0', b'0'),
	('142cb08f-7c31-21fa-8e90-67245e8b283e', 'Phí vệ sinh hành lang tháng 5', '39446ba3-3071-7af6-a5a9-deaf32c96293', '541c96a6-4e24-27fe-6610-dde5fda516a2', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 0, b'0', 20000, b'1', b'1', b'1', b'0', b'1', b'1', '1970-01-01 00:07:13', 'Letha Bolt', '1970-01-01 00:00:04', 1, b'0', b'0'),
	('14c0ce35-1687-459c-1acb-66948daf6128', 'Tổ chức lễ hội EGA', '39446ba3-3071-7af6-a5a9-deaf32c96293', '541c96a6-4e24-27fe-6610-dde5fda516a2', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 2, b'0', 660000, b'1', b'1', b'0', b'0', b'1', b'0', '1970-01-01 00:01:38', 'Melia Gates', '2015-03-30 02:54:20', 1, b'1', b'0'),
	('17120d02-6ab5-3e43-18cb-66948daf6128', 'Xây nhà vệ sinh ', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '4f610a3d-21c1-4b2b-c4fe-7f9a08424f7b', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 0, b'0', 80000, b'1', b'1', b'1', b'0', b'1', b'0', '1980-03-03 23:10:54', 'Miyoko Mckinney', '1971-12-01 02:05:32', 1, b'1', b'0'),
	('1785d6d7-5898-2235-a17d-e8c757976496', 'Bảo hiểm xã hội năm 3', '79aca385-65e3-1ebe-f488-479bce9b28fc', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 0, b'0', 2100000, b'1', b'1', b'0', b'0', b'1', b'1', '1980-02-24 08:23:19', 'Sanjuanita Conners', '1975-05-04 10:15:51', 1, b'1', b'0'),
	('1b336f56-7ee3-7ceb-1ccb-66948daf6128', 'Nước uống cho thí sinh THPT ', '447816de-6069-15bf-de3d-c9e9e9038fe2', '3b880afd-77ba-69c9-6510-dde5fda516a2', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 2, b'0', 1140000, b'1', b'0', b'1', b'1', b'0', b'1', '1970-01-01 00:04:31', 'Alejandro Espinal', '1970-01-01 00:00:18', 1, b'0', b'0'),
	('1c2187a3-6d94-2ded-21cb-66948daf6128', 'Phu phí học nghề khối 12', '39446ba3-3071-7af6-a5a9-deaf32c96293', '3b880afd-77ba-69c9-6510-dde5fda516a2', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 2, b'0', 1980000, b'1', b'0', b'1', b'1', b'0', b'0', '2007-04-17 17:59:05', 'Selina Pfeiffer', '1976-01-29 06:51:02', 1, b'1', b'0'),
	('1ded3dd7-32db-5bc9-9190-67245e8b283e', 'Gây quỹ khuyến học', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '3b880afd-77ba-69c9-6510-dde5fda516a2', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'0', 400000, b'1', b'1', b'0', b'1', b'1', b'1', '2010-06-05 03:35:53', 'Winnifred Brantley', '1983-03-02 04:58:48', 1, b'1', b'0'),
	('1eb07f4e-7018-6d54-6b92-08c864661f9c', 'Phí vệ sinh hành lang tháng 4', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '541c96a6-4e24-27fe-6610-dde5fda516a2', '26021185-77af-263c-842a-acc8fc2f00af', 1, b'1', 2580000, b'0', b'0', b'1', b'1', b'1', b'0', NULL, NULL, '1995-02-20 15:56:09', 0, b'0', b'0'),
	('1f22399e-14b4-5c2b-8132-6a1673ffca7c', 'Phí vệ sinh hành lang tháng 6', '71952621-23c8-61d2-d0eb-e423f1575e00', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 0, b'0', 620000, b'1', b'0', b'0', b'0', b'0', b'0', '1996-02-22 20:34:24', 'Curtis Hutson', '1981-10-11 05:53:10', 1, b'1', b'0'),
	('1f8d7e46-1d1e-335f-79dd-867949feb8b5', 'Sách tham khảo lớp 3', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 3, b'1', 920000, b'0', b'0', b'0', b'1', b'1', b'0', '1992-12-10 08:34:29', 'Malcolm Coward', NULL, 0, b'0', b'0'),
	('205a3e0a-13fe-3557-8232-6a1673ffca7c', 'Phí vệ sinh hành lang tháng 7', '447816de-6069-15bf-de3d-c9e9e9038fe2', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '26021185-77af-263c-842a-acc8fc2f00af', 1, b'1', 840000, b'0', b'1', b'1', b'0', b'0', b'0', NULL, NULL, NULL, 0, b'0', b'0'),
	('20d0b9f3-3e65-1639-9d7d-e8c757976496', 'Xây trường', '71952621-23c8-61d2-d0eb-e423f1575e00', '4f610a3d-21c1-4b2b-c4fe-7f9a08424f7b', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 1, b'1', 1300000, b'1', b'1', b'1', b'0', b'0', b'0', '1970-01-01 00:13:11', 'Adan Pulido', '1986-11-29 14:56:10', 1, b'0', b'0'),
	('22032557-51a3-4005-1263-eeb1d8ed8cef', 'Sách giáo khoa lớp 3', '79aca385-65e3-1ebe-f488-479bce9b28fc', '541c96a6-4e24-27fe-6610-dde5fda516a2', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 2, b'0', 1620000, b'1', b'0', b'0', b'1', b'1', b'1', '1970-01-01 00:00:38', 'Logan Flannery', NULL, 1, b'1', b'0'),
	('24629593-3d34-32fd-997d-e8c757976496', 'Học thêm hóa', '39446ba3-3071-7af6-a5a9-deaf32c96293', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 3, b'1', 600000, b'1', b'0', b'1', b'0', b'1', b'1', '1970-01-01 00:01:28', 'Elli Robertson', '2012-05-18 22:50:51', 1, b'1', b'0'),
	('247986de-4165-651a-9490-67245e8b283e', 'Cơ sở vật chất khu A', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '541c96a6-4e24-27fe-6610-dde5fda516a2', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 1, b'1', 960000, b'0', b'0', b'0', b'0', b'0', b'1', '1989-09-06 01:45:57', 'Lizzie Krueger', '1990-05-10 02:54:11', 0, b'0', b'0'),
	('276e9765-4c6a-4239-0b80-e8e2a817c80e', 'Học nâng cao đợt 2', '39446ba3-3071-7af6-a5a9-deaf32c96293', '4f610a3d-21c1-4b2b-c4fe-7f9a08424f7b', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 1, b'1', 2460000, b'0', b'0', b'0', b'0', b'1', b'0', '1973-09-12 21:00:39', 'Elwood Desimone', '1982-11-07 20:59:44', 0, b'1', b'0'),
	('284ccb05-337b-7e6f-9090-67245e8b283e', 'Đoàn phí đợt 2', '79aca385-65e3-1ebe-f488-479bce9b28fc', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'0', 360000, b'1', b'0', b'1', b'0', b'0', b'1', '1979-11-04 07:36:36', 'Ariel Hermann', '1970-01-01 00:00:25', 1, b'0', b'0'),
	('2bbbd485-6df2-536a-7e32-6a1673ffca7c', 'Sữa học đường tháng 7', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'0', 200000, b'0', b'0', b'0', b'0', b'1', b'1', '1970-01-01 00:01:04', 'Denisha Mcginnis', NULL, 0, b'0', b'0'),
	('2bf413d3-7a2c-217a-78dd-867949feb8b5', 'Đồng phục mùa hè', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '3b880afd-77ba-69c9-6510-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'0', 720000, b'1', b'1', b'0', b'1', b'0', b'1', '1987-09-13 19:19:49', 'Cordelia Key', '1998-10-30 19:25:06', 1, b'1', b'0'),
	('2d558039-6f60-6d55-fd17-7000f455f3d5', 'Sữa học đường tháng 1', '71952621-23c8-61d2-d0eb-e423f1575e00', '3b880afd-77ba-69c9-6510-dde5fda516a2', '26021185-77af-263c-842a-acc8fc2f00af', 1, b'1', 2120000, b'0', b'0', b'0', b'0', b'1', b'0', '1970-01-01 00:37:44', 'Tanner Van', NULL, 0, b'0', b'0'),
	('2dcedb9c-6c32-7d27-977d-e8c757976496', 'Vệ sinh khu A', '79aca385-65e3-1ebe-f488-479bce9b28fc', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 0, b'0', 340000, b'0', b'1', b'0', b'0', b'1', b'1', '2008-05-29 19:50:03', 'Laura Barger', '2008-05-06 11:25:54', 0, b'1', b'0'),
	('2de001fe-529b-33ad-0280-e8e2a817c80e', 'Phí nộp phạt vi phạm quy định', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '3b880afd-77ba-69c9-6510-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'0', 780000, b'1', b'0', b'1', b'0', b'0', b'0', '1979-12-28 17:38:31', 'Oliva Coble', '1983-08-28 06:12:39', 1, b'0', b'0'),
	('2ff059da-69a9-17a4-fc17-7000f455f3d5', 'Bảo hiểm y tế ', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 0, b'0', 1600000, b'0', b'1', b'1', b'1', b'1', b'1', '1990-04-06 23:26:00', 'Darrick Olmstead', NULL, 0, b'0', b'1'),
	('336f81b7-417d-7e3a-1363-eeb1d8ed8cef', 'Cơ sở vật chất khu B', '447816de-6069-15bf-de3d-c9e9e9038fe2', '3b880afd-77ba-69c9-6510-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 3, b'1', 2220000, b'1', b'1', b'1', b'0', b'1', b'1', '1970-01-01 00:00:10', 'Abbie Gurley', '1970-01-01 00:00:44', 1, b'1', b'0'),
	('33851c36-6445-4680-23cb-66948daf6128', 'Du lịch Bái Đính', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '427b1814-60ed-47cf-edb5-aae5d250830a', 1, b'1', 2440000, b'1', b'0', b'0', b'1', b'0', b'1', '1970-01-01 02:20:49', 'Merlene Collazo', '1998-04-12 07:06:33', 1, b'0', b'0'),
	('34cde64f-62e4-186c-77dd-867949feb8b5', 'Tiền ăn bán chú tháng 1', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'0', 680000, b'1', b'1', b'1', b'0', b'0', b'1', '2010-03-02 07:43:57', 'Marc Pickering', '1970-01-01 00:16:31', 1, b'1', b'0'),
	('3590dd80-43d2-1325-8732-6a1673ffca7c', 'Học phí kỳ 3', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '26021185-77af-263c-842a-acc8fc2f00af', 3, b'1', 1820000, b'0', b'0', b'0', b'0', b'0', b'1', '2007-02-17 15:38:55', 'Abram Swank', '1970-01-01 00:00:07', 0, b'1', b'0'),
	('3599ef50-13ed-5404-0e63-eeb1d8ed8cef', 'Bảo hiểm y tế năm 3', '39446ba3-3071-7af6-a5a9-deaf32c96293', '541c96a6-4e24-27fe-6610-dde5fda516a2', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 1, b'1', 560000, b'0', b'0', b'1', b'1', b'1', b'0', '1993-05-06 04:38:21', 'Lilla Perez', '2017-10-06 01:00:30', 0, b'1', b'0'),
	('37cf0ec7-4909-5dc9-a37d-e8c757976496', 'Tham quan Văn miếu Quốc Tử Giám', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '4f610a3d-21c1-4b2b-c4fe-7f9a08424f7b', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 2, b'0', 2620000, b'1', b'0', b'1', b'0', b'0', b'1', '1999-09-03 01:00:22', 'Patricia Cornett', '1983-08-02 21:41:58', 1, b'0', b'0'),
	('3856e8f7-535c-632a-83dd-867949feb8b5', 'Quỹ lớp Kỳ 2', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '26021185-77af-263c-842a-acc8fc2f00af', 0, b'0', 2400000, b'1', b'1', b'0', b'0', b'1', b'1', '1970-01-01 00:08:43', 'Edith Lord', '1970-01-01 00:07:04', 1, b'1', b'0'),
	('3965bd1a-2544-467d-80dd-867949feb8b5', 'Vệ sinh khu giáo viên', '79aca385-65e3-1ebe-f488-479bce9b28fc', '4f610a3d-21c1-4b2b-c4fe-7f9a08424f7b', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 1, b'1', 2140000, b'0', b'0', b'1', b'1', b'0', b'1', '1990-12-30 19:04:45', 'Abel Paulson', '1970-01-01 00:01:09', 0, b'0', b'0'),
	('3ab17eb8-4928-4275-8332-6a1673ffca7c', 'Thu phí học nghề khối 12', '79aca385-65e3-1ebe-f488-479bce9b28fc', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '26021185-77af-263c-842a-acc8fc2f00af', 1, b'1', 1120000, b'1', b'0', b'1', b'1', b'1', b'0', '1987-03-20 06:58:59', 'Derrick Ruiz', '1995-04-25 23:27:06', 1, b'1', b'0'),
	('3abc4ce5-462f-5db9-9e7d-e8c757976496', 'Bảo hiểm y tế kỳ 2', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '26021185-77af-263c-842a-acc8fc2f00af', 3, b'1', 1580000, b'0', b'0', b'0', b'0', b'0', b'1', '1970-01-01 00:00:36', 'Halley Bostic', NULL, 0, b'1', b'0'),
	('3b4d46a3-7a40-30a2-fe17-7000f455f3d5', 'Học nâng cao vật lý', '39446ba3-3071-7af6-a5a9-deaf32c96293', '541c96a6-4e24-27fe-6610-dde5fda516a2', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 1, b'1', 2540000, b'0', b'1', b'0', b'0', b'0', b'1', '1970-01-01 02:09:58', 'Hank Myles', '2018-08-10 17:43:29', 0, b'1', b'0'),
	('3ce59559-28e3-40e4-1463-eeb1d8ed8cef', 'Tiền ăn bán chú tháng 2', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '541c96a6-4e24-27fe-6610-dde5fda516a2', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 2, b'0', 2560000, b'0', b'1', b'0', b'0', b'0', b'1', '1981-10-03 10:09:53', 'Antonia Paine', '2006-08-27 02:38:10', 0, b'1', b'0'),
	('3d780ac8-3fb5-5c89-8932-6a1673ffca7c', 'Sữa học đường tháng 5', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 3, b'1', 2160000, b'1', b'1', b'1', b'0', b'0', b'1', NULL, NULL, NULL, 1, b'0', b'0'),
	('3ef08d53-5bf3-1e97-9790-67245e8b283e', 'Tổ chức 26/4', '71952621-23c8-61d2-d0eb-e423f1575e00', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 1, b'1', 1400000, b'0', b'0', b'0', b'1', b'1', b'0', '2003-03-08 10:14:47', 'Ronnie Roby', NULL, 0, b'0', b'0'),
	('3f66f2d6-688b-4161-5f92-08c864661f9c', 'Sổ liên lạc điện tử', '447816de-6069-15bf-de3d-c9e9e9038fe2', '4f610a3d-21c1-4b2b-c4fe-7f9a08424f7b', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 0, b'0', 700000, b'1', b'0', b'1', b'0', b'1', b'0', '2007-07-19 08:08:17', 'Alida Jobe', '2003-01-21 14:47:12', 1, b'0', b'0'),
	('3f851737-2976-4bc0-22cb-66948daf6128', 'Sách tham khảo lớp 2', '79aca385-65e3-1ebe-f488-479bce9b28fc', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 1, b'1', 2320000, b'0', b'1', b'0', b'0', b'1', b'0', '1970-01-02 02:12:58', 'Brett Abreu', NULL, 0, b'0', b'0'),
	('40036f5e-657f-2c3d-9f7d-e8c757976496', 'Học thêm', '71952621-23c8-61d2-d0eb-e423f1575e00', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '26021185-77af-263c-842a-acc8fc2f00af', 3, b'1', 1680000, b'0', b'1', b'0', b'0', b'0', b'1', NULL, NULL, '1970-01-01 00:00:39', 0, b'0', b'0'),
	('404fe340-1fd3-414b-aadb-e5d54223c257', 'Đồng phục mùa đông', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'0', 420000, b'0', b'0', b'1', b'0', b'0', b'1', '1970-01-01 00:01:23', 'Gayle Baugh', '1970-01-01 00:57:34', 0, b'1', b'0'),
	('4296b118-76aa-3241-7edd-867949feb8b5', 'Cơ sở vật chất ', '71952621-23c8-61d2-d0eb-e423f1575e00', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '427b1814-60ed-47cf-edb5-aae5d250830a', 1, b'1', 1940000, b'1', b'0', b'1', b'1', b'0', b'0', '1970-01-01 00:00:02', 'Lesia Hatch', '1972-07-18 19:08:47', 1, b'0', b'0'),
	('438fec4c-2dad-30d7-a07d-e8c757976496', 'Học phí đợt 2', '71952621-23c8-61d2-d0eb-e423f1575e00', '3b880afd-77ba-69c9-6510-dde5fda516a2', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 3, b'1', 1860000, b'0', b'0', b'0', b'1', b'0', b'1', '1988-02-08 07:28:54', 'Debbra Packer', NULL, 0, b'0', b'0'),
	('452ffb43-4668-4d84-9bb7-c6ae88abd7b7', 'string 2', NULL, NULL, '2b031b59-5276-589c-9d75-2a7ae1c799c8', 0, b'1', 0, b'1', b'1', b'1', b'1', b'1', b'1', '2021-06-15 17:28:12', 'NDDONG', NULL, 0, b'1', b'0'),
	('45536100-7fba-5a99-24cb-66948daf6128', 'Sự kiện trại hè vui nhộn', '71952621-23c8-61d2-d0eb-e423f1575e00', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '26021185-77af-263c-842a-acc8fc2f00af', 0, b'0', 2520000, b'0', b'1', b'1', b'1', b'1', b'0', '1986-04-04 05:31:07', 'Eboni Rendon', NULL, 0, b'0', b'0'),
	('4577565a-7e3e-493a-74dd-867949feb8b5', 'Trang bị máy tính ho phòng tin học', '447816de-6069-15bf-de3d-c9e9e9038fe2', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 3, b'1', 140000, b'1', b'0', b'0', b'0', b'1', b'0', '1972-10-04 22:11:42', 'Felix Alba', '1974-09-08 07:56:22', 1, b'1', b'0'),
	('46f514e3-3598-177c-6192-08c864661f9c', 'Vệ sinh', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '26021185-77af-263c-842a-acc8fc2f00af', 0, b'0', 940000, b'1', b'1', b'1', b'0', b'1', b'1', '1970-08-01 03:57:24', 'Carley Valdez', NULL, 1, b'1', b'0'),
	('4729a19e-5a81-6e74-6a92-08c864661f9c', 'Sách tham khảo lớp 4', '447816de-6069-15bf-de3d-c9e9e9038fe2', '3b880afd-77ba-69c9-6510-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'0', 2340000, b'0', b'1', b'1', b'0', b'1', b'0', '1994-06-07 08:05:18', 'Alonzo Arce', NULL, 0, b'0', b'0'),
	('47405a55-5845-562c-7ddd-867949feb8b5', 'Nước uống cho hoạt động', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '541c96a6-4e24-27fe-6610-dde5fda516a2', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'0', 1780000, b'1', b'0', b'1', b'0', b'0', b'0', '1970-01-01 00:01:15', 'Benito Agee', NULL, 1, b'0', b'0'),
	('4760d71f-6e2f-5b32-19cb-66948daf6128', 'Vệ sinh lớp học', '447816de-6069-15bf-de3d-c9e9e9038fe2', '541c96a6-4e24-27fe-6610-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'0', 220000, b'1', b'1', b'1', b'0', b'1', b'1', '2004-03-30 13:34:16', 'Stanford Sullivan', '1987-02-27 13:26:27', 1, b'1', b'0'),
	('47f60f67-6087-2a86-abdb-e5d54223c257', 'Xây lán xe khu A', '447816de-6069-15bf-de3d-c9e9e9038fe2', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '26021185-77af-263c-842a-acc8fc2f00af', 1, b'1', 740000, b'1', b'1', b'1', b'0', b'0', b'0', '1970-01-01 01:00:18', 'Reba Gregg', '2001-12-29 15:59:33', 1, b'0', b'0'),
	('48c40821-1c72-189a-6792-08c864661f9c', 'Đoàn phí tháng 2', '447816de-6069-15bf-de3d-c9e9e9038fe2', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '26021185-77af-263c-842a-acc8fc2f00af', 3, b'1', 2020000, b'0', b'0', b'0', b'0', b'1', b'1', '2020-05-08 09:22:55', 'Hosea Spears', '1970-01-01 01:41:19', 0, b'1', b'0'),
	('4cd4bba1-49ac-6e4c-b4db-e5d54223c257', 'Mua dụng cụ thực hành vật lý', '71952621-23c8-61d2-d0eb-e423f1575e00', '3b880afd-77ba-69c9-6510-dde5fda516a2', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 3, b'1', 2380000, b'0', b'0', b'1', b'1', b'0', b'0', '1970-01-01 00:11:09', 'Darwin Kay', '1970-01-01 00:00:09', 0, b'1', b'0'),
	('4d6f3e2c-0885-4ffb-93e0-ca53b42d169a', 'test31231', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 3, b'1', 321231, b'1', b'0', b'0', b'0', b'0', b'0', '2021-06-20 09:34:36', 'NDDONG', NULL, 0, b'0', b'0'),
	('4d79d901-1edc-5c5b-0780-e8e2a817c80e', 'Đóng bàn ghế mới', '79aca385-65e3-1ebe-f488-479bce9b28fc', '3b880afd-77ba-69c9-6510-dde5fda516a2', '26021185-77af-263c-842a-acc8fc2f00af', 3, b'1', 1840000, b'0', b'1', b'1', b'0', b'0', b'1', '1970-01-01 00:06:40', 'Elaina Gruber', '1970-01-01 00:00:04', 0, b'0', b'0'),
	('4d7b21db-2e02-12b7-a9db-e5d54223c257', 'Ủng hộ đồng bào vũng lũ', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 1, b'1', 380000, b'0', b'1', b'1', b'1', b'0', b'0', '1970-01-01 00:15:42', 'Adam Maddox', '2007-09-07 05:59:09', 0, b'1', b'0'),
	('4e01ca19-178d-1579-9c90-67245e8b283e', 'Sữa học đường tháng 11', '447816de-6069-15bf-de3d-c9e9e9038fe2', '541c96a6-4e24-27fe-6610-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'0', 2500000, b'1', b'1', b'0', b'0', b'0', b'1', '1999-09-17 10:33:09', 'Celinda Block', '1983-05-25 20:14:21', 1, b'1', b'0'),
	('4e272fc4-7875-78d6-7d32-6a1673ffca7c', 'Phí trông giữ phương tiện', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'0', 60000, b'0', b'0', b'0', b'0', b'1', b'0', '1981-04-26 00:24:05', 'Marcos Abraham', '1970-01-01 00:00:08', 0, b'0', b'0'),
	('4eceddac-7dc2-38ea-7bdd-867949feb8b5', 'Tiền ăn bán chú tháng 7', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '3b880afd-77ba-69c9-6510-dde5fda516a2', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 1, b'1', 1320000, b'1', b'0', b'1', b'0', b'1', b'1', NULL, NULL, '1974-01-01 00:01:56', 1, b'0', b'0'),
	('4f6d1696-757a-42a0-0a80-e8e2a817c80e', 'Phí vệ sinh hành lang tháng 10', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'0', 2420000, b'1', b'1', b'0', b'1', b'0', b'0', '1970-01-01 00:01:21', 'Shenita Pulley', NULL, 1, b'0', b'0'),
	('50d65da3-631c-5139-9b90-67245e8b283e', 'Sữa học đường tháng 9', '39446ba3-3071-7af6-a5a9-deaf32c96293', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'1', 2360000, b'1', b'0', b'1', b'0', b'0', b'1', '1993-10-16 21:06:32', 'Agripina Meadows', '1970-01-01 00:41:56', 1, b'0', b'0'),
	('52f7159d-5242-1af8-9c7d-e8c757976496', 'Nước uống', '39446ba3-3071-7af6-a5a9-deaf32c96293', '3b880afd-77ba-69c9-6510-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'0', 1180000, b'0', b'1', b'0', b'1', b'0', b'0', '1993-02-21 19:22:02', 'Calvin Looney', '1998-07-30 02:55:32', 0, b'1', b'0'),
	('53f6b59c-6af6-4204-6292-08c864661f9c', 'Phí vệ sinh hành lang tháng 9', '79aca385-65e3-1ebe-f488-479bce9b28fc', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 3, b'1', 1240000, b'1', b'0', b'1', b'1', b'0', b'0', '1991-02-06 15:24:02', 'Calvin Abrams', '1970-01-01 00:00:06', 1, b'1', b'0'),
	('5608f456-3b97-2e05-5d92-08c864661f9c', 'Sách giáo khoa ', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '26021185-77af-263c-842a-acc8fc2f00af', 1, b'1', 500000, b'1', b'1', b'1', b'0', b'0', b'0', '1993-03-21 12:58:55', 'Myles Angel', '2009-10-11 00:28:00', 1, b'0', b'0'),
	('5660d465-6020-48f3-75dd-867949feb8b5', 'Sách giáo khoa lớp 2', '447816de-6069-15bf-de3d-c9e9e9038fe2', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'0', 320000, b'1', b'1', b'0', b'0', b'0', b'0', '2003-09-01 15:49:51', 'Freeman Selby', NULL, 1, b'0', b'0'),
	('56957607-562f-5d6d-1ecb-66948daf6128', 'Gây quỹ khuyến học tháng 2', '39446ba3-3071-7af6-a5a9-deaf32c96293', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 3, b'1', 1520000, b'0', b'0', b'1', b'1', b'0', b'0', '1970-01-01 01:15:49', 'Alexa Saucedo', '1970-01-01 00:09:11', 0, b'0', b'0'),
	('56e1088a-fd1b-496d-aab8-0aa53a0e5930', 'test', '39446ba3-3071-7af6-a5a9-deaf32c96293', '3b880afd-77ba-69c9-6510-dde5fda516a2', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'1', 12121, b'1', b'1', b'1', b'1', b'1', b'1', '2021-06-20 02:26:36', 'NDDONG', NULL, 2, b'1', b'0'),
	('56e25d6f-cb62-43f0-9e62-89648dc87817', 'test6', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'0', 2334234, b'0', b'0', b'0', b'0', b'0', b'1', '2021-06-20 00:44:43', 'NDDONG', NULL, 1, b'0', b'0'),
	('58d8d8a7-140b-5c87-82dd-867949feb8b5', 'Thu phí học nghề khối 11', '39446ba3-3071-7af6-a5a9-deaf32c96293', '4f610a3d-21c1-4b2b-c4fe-7f9a08424f7b', '427b1814-60ed-47cf-edb5-aae5d250830a', 1, b'0', 2300000, b'1', b'0', b'1', b'1', b'1', b'1', '1983-11-08 06:14:07', 'Ada Edmond', '1970-01-01 00:00:22', 1, b'0', b'0'),
	('59d19422-6657-452e-a7db-e5d54223c257', 'Sữa học đường tháng 6', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '3b880afd-77ba-69c9-6510-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'0', 180000, b'0', b'0', b'1', b'1', b'1', b'1', NULL, NULL, NULL, 0, b'0', b'0'),
	('5b2fcdf5-2050-7cb2-8f90-67245e8b283e', 'Học phí', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '3b880afd-77ba-69c9-6510-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'0', 240000, b'1', b'0', b'1', b'1', b'1', b'1', '1973-04-29 10:12:08', 'Nathan Salisbury', NULL, 1, b'0', b'1'),
	('5badffd8-18c8-3f76-6492-08c864661f9c', 'Tiền ăn bán chú tháng 5 ', '79aca385-65e3-1ebe-f488-479bce9b28fc', '541c96a6-4e24-27fe-6610-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 1, b'1', 1740000, b'0', b'1', b'0', b'1', b'0', b'1', '2012-03-03 15:23:46', 'Owen Alston', '1970-01-01 00:10:14', 0, b'1', b'0'),
	('5c63ba8f-59bb-6d2f-9990-67245e8b283e', 'Tổ chức 20/11', '79aca385-65e3-1ebe-f488-479bce9b28fc', '541c96a6-4e24-27fe-6610-dde5fda516a2', '26021185-77af-263c-842a-acc8fc2f00af', 3, b'1', 1760000, b'1', b'1', b'1', b'0', b'0', b'0', '1998-12-13 17:02:47', 'Bradford Alfaro', '2005-03-07 19:22:26', 1, b'1', b'0'),
	('5fbbda7e-7566-416f-9b7d-e8c757976496', 'Phí vệ sinh hành lang tháng 8', '71952621-23c8-61d2-d0eb-e423f1575e00', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'0', 1080000, b'1', b'1', b'1', b'0', b'1', b'1', '2003-12-20 18:22:50', 'Aimee Stamm', NULL, 1, b'0', b'0'),
	('60084fec-3509-2779-8432-6a1673ffca7c', 'Tiền ăn bán chú tháng 8', '39446ba3-3071-7af6-a5a9-deaf32c96293', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '26021185-77af-263c-842a-acc8fc2f00af', 1, b'1', 1220000, b'0', b'1', b'1', b'1', b'0', b'1', '1976-01-25 06:39:41', 'Burt Hughes', '1970-01-01 00:00:07', 0, b'1', b'0'),
	('6081dc00-4df0-5184-9690-67245e8b283e', 'Học nâng cao', '447816de-6069-15bf-de3d-c9e9e9038fe2', '541c96a6-4e24-27fe-6610-dde5fda516a2', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 3, b'1', 1340000, b'1', b'1', b'0', b'1', b'0', b'0', '2015-04-01 01:51:51', 'Abel Christian', NULL, 1, b'1', b'0'),
	('6149c4f4-425b-60e0-b3db-e5d54223c257', 'Tiền ăn bán chú tháng 9', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '427b1814-60ed-47cf-edb5-aae5d250830a', 3, b'1', 2280000, b'0', b'1', b'0', b'0', b'1', b'1', '1994-12-02 01:43:02', 'Addie Lincoln', '1984-10-11 00:07:12', 0, b'1', b'0'),
	('61a45b9e-55c1-3dbb-f917-7000f455f3d5', 'Sữa học đường tháng 8', '39446ba3-3071-7af6-a5a9-deaf32c96293', '4f610a3d-21c1-4b2b-c4fe-7f9a08424f7b', '26021185-77af-263c-842a-acc8fc2f00af', 3, b'1', 900000, b'1', b'1', b'1', b'0', b'0', b'0', '1970-08-11 02:39:57', 'Bertram Herzog', NULL, 1, b'1', b'0'),
	('6429b0f4-1391-7f32-9390-67245e8b283e', 'Cơ sở vật chất cho phòng họp', '79aca385-65e3-1ebe-f488-479bce9b28fc', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 1, b'1', 760000, b'1', b'0', b'1', b'0', b'0', b'1', '1989-05-17 17:39:01', 'Jarod Bourgeois', NULL, 1, b'0', b'0'),
	('645f2e5c-7670-66a0-6092-08c864661f9c', 'Sách tham khảo lớp 5', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '26021185-77af-263c-842a-acc8fc2f00af', 1, b'1', 860000, b'1', b'1', b'1', b'1', b'0', b'1', '2014-04-04 17:52:12', 'Newton Graves', '1970-01-01 00:00:38', 1, b'1', b'0'),
	('6764ab86-6fcc-2757-8032-6a1673ffca7c', 'ách giáo khoa lớp 5', '79aca385-65e3-1ebe-f488-479bce9b28fc', '541c96a6-4e24-27fe-6610-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'0', 520000, b'1', b'0', b'1', b'1', b'1', b'1', '1970-01-01 00:05:13', 'Jerome Gipson', '1970-01-01 00:00:10', 1, b'1', b'0'),
	('67ef417b-756d-6f15-a27d-e8c757976496', 'Sách tham khảo lớp 1', '39446ba3-3071-7af6-a5a9-deaf32c96293', '541c96a6-4e24-27fe-6610-dde5fda516a2', '26021185-77af-263c-842a-acc8fc2f00af', 3, b'0', 2200000, b'0', b'0', b'0', b'0', b'1', b'0', '1991-04-14 14:43:07', 'Ora Dorris', NULL, 0, b'0', b'0'),
	('6916f8cf-1279-16d8-9290-67245e8b283e', 'Quỹ lớp đợt 2', '71952621-23c8-61d2-d0eb-e423f1575e00', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'0', 580000, b'0', b'0', b'0', b'1', b'0', b'0', '2009-08-05 09:00:58', 'Josephine Norwood', '1995-12-20 20:39:31', 0, b'1', b'0'),
	('69209d34-0b03-4f0a-b819-5bdec8f08f8a', 'test7', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'0', 2334234, b'0', b'0', b'0', b'0', b'0', b'1', '2021-06-20 00:48:25', 'NDDONG', NULL, 1, b'0', b'0'),
	('698623e9-1def-6cb3-fa17-7000f455f3d5', 'Phí vệ sinh hành lang tháng 1', '39446ba3-3071-7af6-a5a9-deaf32c96293', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '26021185-77af-263c-842a-acc8fc2f00af', 1, b'1', 1160000, b'0', b'0', b'0', b'1', b'1', b'1', '1970-01-01 00:09:14', 'Myrtis Thornhill', NULL, 0, b'1', b'0'),
	('69cdb3c5-55bc-2a7a-9a7d-e8c757976496', 'Phí vệ sinh hành lang tháng 3', '39446ba3-3071-7af6-a5a9-deaf32c96293', '541c96a6-4e24-27fe-6610-dde5fda516a2', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 1, b'1', 820000, b'0', b'1', b'1', b'1', b'0', b'1', '1980-08-14 11:50:37', 'Bud Grubbs', '1970-01-01 01:59:55', 0, b'1', b'0'),
	('6a4d99cd-242a-6200-7add-867949feb8b5', 'Bảo hiểm xã hội năm 4', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '26021185-77af-263c-842a-acc8fc2f00af', 0, b'0', 980000, b'1', b'1', b'1', b'1', b'1', b'1', '1970-01-01 00:02:22', 'Celestine Hong', NULL, 1, b'0', b'0'),
	('6a779fff-7bc4-54f4-b5db-e5d54223c257', 'Bảo hiểm y tế năm 1', '447816de-6069-15bf-de3d-c9e9e9038fe2', '3b880afd-77ba-69c9-6510-dde5fda516a2', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 0, b'0', 2600000, b'1', b'1', b'0', b'1', b'0', b'1', '1977-09-05 07:51:57', 'Syble Elder', '2013-06-15 16:24:42', 1, b'1', b'0'),
	('6c97b353-5d7d-4095-1dcb-66948daf6128', 'Phí vệ sinh hành lang tháng 12', '447816de-6069-15bf-de3d-c9e9e9038fe2', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'0', 1260000, b'1', b'1', b'1', b'0', b'1', b'0', '1985-12-11 07:23:56', 'Hobert Adam', NULL, 1, b'0', b'0'),
	('6de8272b-7b3b-319f-8a32-6a1673ffca7c', 'Phí vệ sinh hành lang tháng 11', '447816de-6069-15bf-de3d-c9e9e9038fe2', '541c96a6-4e24-27fe-6610-dde5fda516a2', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 1, b'1', 2480000, b'0', b'0', b'0', b'1', b'0', b'0', '1978-12-08 00:03:56', 'Harrison Abel', '1970-01-01 00:00:23', 0, b'1', b'0'),
	('70253ec7-2e38-67a9-b1db-e5d54223c257', 'Dụng cụ thể dục ', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 2, b'0', 1640000, b'1', b'1', b'0', b'1', b'0', b'1', '2007-02-22 12:59:27', 'Armando Alvarez', '1970-01-01 00:09:31', 1, b'1', b'0'),
	('7050d79b-6948-3c66-1fcb-66948daf6128', 'Sách giáo khoa lớp 1', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '3b880afd-77ba-69c9-6510-dde5fda516a2', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'0', 1700000, b'1', b'0', b'0', b'0', b'1', b'0', '1970-01-01 00:09:39', 'Sonya Tinsley', NULL, 1, b'1', b'0'),
	('70d5acf3-2d43-7ebb-9a90-67245e8b283e', 'Tiền ăn bán chú tháng 3', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '541c96a6-4e24-27fe-6610-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'0', 2080000, b'0', b'1', b'1', b'0', b'0', b'0', '1970-01-01 00:13:12', 'Kizzy Hightower', NULL, 0, b'1', b'0'),
	('72ce912f-6015-2e14-fb17-7000f455f3d5', 'Tiền ăn bán chú tháng 12', '39446ba3-3071-7af6-a5a9-deaf32c96293', '541c96a6-4e24-27fe-6610-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'0', 1420000, b'1', b'1', b'1', b'0', b'0', b'0', '1979-09-26 18:37:29', 'Mervin Lyon', '1988-03-09 08:30:57', 1, b'0', b'0'),
	('74017ba6-559b-3426-8532-6a1673ffca7c', 'Tiền ăn bán chú tháng 6', '79aca385-65e3-1ebe-f488-479bce9b28fc', '4f610a3d-21c1-4b2b-c4fe-7f9a08424f7b', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 0, b'0', 1480000, b'1', b'1', b'1', b'0', b'0', b'0', NULL, NULL, '1970-01-01 00:00:09', 1, b'0', b'0'),
	('7623d42f-35f4-1ce5-987d-e8c757976496', 'Học thêm văn', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '26021185-77af-263c-842a-acc8fc2f00af', 0, b'0', 480000, b'1', b'0', b'1', b'1', b'0', b'1', '1974-11-07 17:08:25', 'Gertie Abel', '1970-01-01 02:25:46', 1, b'1', b'0'),
	('7686595d-16d5-33b3-0080-e8e2a817c80e', 'Xây lán xe', '79aca385-65e3-1ebe-f488-479bce9b28fc', '541c96a6-4e24-27fe-6610-dde5fda516a2', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'0', 160000, b'0', b'1', b'0', b'0', b'0', b'0', '1993-12-14 03:23:26', 'Eusebia Noland', '1971-04-27 14:43:35', 0, b'1', b'0'),
	('768f8e64-7d10-20c9-967d-e8c757976496', 'Sữa học đường', '39446ba3-3071-7af6-a5a9-deaf32c96293', '3b880afd-77ba-69c9-6510-dde5fda516a2', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 3, b'1', 120000, b'1', b'0', b'0', b'0', b'1', b'1', '1977-12-28 14:11:58', 'Oma Lawler', NULL, 1, b'0', b'0'),
	('76e1d79b-1012-44bd-8f4d-54dc501ba964', 'test311', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 0, b'0', 12121, b'0', b'0', b'0', b'0', b'0', b'0', '2021-06-19 23:35:15', 'NDDONG', '2021-06-20 02:23:17', 1, b'0', b'0'),
	('771e3dd1-42bb-2339-acdb-e5d54223c257', 'Tiền ăn bán chú tháng 11', '39446ba3-3071-7af6-a5a9-deaf32c96293', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 0, b'0', 800000, b'1', b'1', b'0', b'0', b'0', b'1', '2013-06-23 21:32:05', 'Corey Musgrove', '1970-01-01 00:10:02', 1, b'1', b'0'),
	('773acde0-4741-351b-6992-08c864661f9c', 'Ủng hộ trẻ em khuyết tật', '39446ba3-3071-7af6-a5a9-deaf32c96293', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '26021185-77af-263c-842a-acc8fc2f00af', 1, b'0', 2260000, b'1', b'1', b'0', b'0', b'1', b'1', '1981-06-02 10:45:27', 'Merrilee Stamper', '2017-05-27 05:01:35', 1, b'0', b'0'),
	('7abe18db-2b8a-5fcb-aedb-e5d54223c257', 'Sữa học đường tháng 12', '71952621-23c8-61d2-d0eb-e423f1575e00', '541c96a6-4e24-27fe-6610-dde5fda516a2', '26021185-77af-263c-842a-acc8fc2f00af', 3, b'1', 1100000, b'1', b'0', b'0', b'0', b'0', b'1', '1970-01-01 02:45:15', 'Sonia Ackerman', '1970-01-01 00:01:09', 1, b'0', b'0'),
	('7e8f50b2-5100-74d8-0480-e8e2a817c80e', 'Hội phù đổng', '79aca385-65e3-1ebe-f488-479bce9b28fc', '3b880afd-77ba-69c9-6510-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 2, b'0', 1200000, b'0', b'0', b'1', b'1', b'0', b'0', '1984-07-21 10:31:07', 'Deedee Strange', NULL, 0, b'0', b'0'),
	('7f4552ee-20f2-2f82-9890-67245e8b283e', 'Sữa học đường đợt 2', '447816de-6069-15bf-de3d-c9e9e9038fe2', '4fe5ee09-2c89-580a-dc49-fe4bedd9e894', '6118a7ff-742b-25db-a9c1-8e252c39bb73', 0, b'0', 1540000, b'0', b'0', b'0', b'1', b'0', b'1', '1974-07-04 18:38:39', 'Bryce Estrada', NULL, 0, b'0', b'0'),
	('87561615-0d7c-4543-a2be-ea0fafc3f834', 'test9', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '26021185-77af-263c-842a-acc8fc2f00af', 0, b'0', 4234, b'0', b'0', b'0', b'0', b'0', b'0', '2021-06-20 01:01:11', 'NDDONG', NULL, 2, b'0', b'0'),
	('929f1fd9-7064-4e2f-95bf-b2bdd0bacb56', 'test30', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'0', 212121, b'0', b'0', b'0', b'0', b'0', b'0', '2021-06-19 23:39:09', 'NDDONG', '2021-06-20 02:03:02', 1, b'1', b'0'),
	('9471a0b8-c3e3-4103-baaa-605154f8cecb', 'Test223', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '26021185-77af-263c-842a-acc8fc2f00af', 3, b'1', 32323, b'0', b'0', b'0', b'1', b'0', b'0', '2021-06-20 16:55:34', 'NDDONG', NULL, 2, b'0', b'0'),
	('94dcc2a3-116a-4a10-9c26-6fe38459ead4', 'test313', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '61e3cc06-6237-222a-7e5b-5b97e23db0bb', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 0, b'0', 12121, b'0', b'0', b'0', b'0', b'0', b'0', '2021-06-20 02:27:13', 'NDDONG', '2021-06-20 09:44:36', 1, b'0', b'0'),
	('9812689f-6ae4-4bee-b25e-4ef658a65fbf', 'tiền điện', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 0, b'0', 32323, b'0', b'0', b'0', b'0', b'0', b'0', '2021-06-19 23:29:14', 'NDDONG', NULL, 1, b'0', b'0'),
	('9f869032-baa2-4d04-a0e6-9d8ff9b594d6', 'test8', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '26021185-77af-263c-842a-acc8fc2f00af', 0, b'0', 4324432, b'0', b'0', b'0', b'0', b'0', b'0', '2021-06-20 00:49:16', 'NDDONG', NULL, 2, b'0', b'0'),
	('a3df399e-b5ea-40d1-ba7b-13f17a2a4cad', 'Test4444', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '541c96a6-4e24-27fe-6610-dde5fda516a2', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'0', 32131, b'1', b'0', b'1', b'0', b'0', b'0', '2021-06-20 09:09:38', 'NDDONG', NULL, 1, b'0', b'0'),
	('c195af96-3716-4e1c-b11c-9fcd6c96f7e1', 'test222', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'1', 312321, b'0', b'0', b'0', b'1', b'0', b'0', '2021-06-20 16:55:04', 'NDDONG', NULL, 2, b'0', b'0'),
	('c7cd5520-f0b1-4845-8591-4f89271e45a9', 'test22', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 2, b'1', 443242, b'1', b'1', b'1', b'1', b'1', b'1', '2021-06-20 16:52:35', 'NDDONG', NULL, 1, b'0', b'0'),
	('e406532f-e827-43d6-9ce1-5162fc162a95', 'test400', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'1', 432432, b'1', b'1', b'1', b'1', b'1', b'1', '2021-06-19 23:39:51', 'NDDONG', '2021-06-20 08:27:52', 1, b'0', b'0'),
	('f3e060f2-af2b-4556-923f-4ac15fd8b6c0', 'test314', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '2b031b59-5276-589c-9d75-2a7ae1c799c8', 0, b'0', 12121, b'0', b'0', b'0', b'0', b'0', b'0', '2021-06-20 02:28:30', 'NDDONG', NULL, 1, b'0', b'0'),
	('f8dd59dd-2648-48bc-8dac-1b348c1d9e02', 'test20', '3541ff76-58f0-6d1a-e836-63d5d5eff719', '7461553a-1f2b-56a6-e8c0-f32a102323e6', '427b1814-60ed-47cf-edb5-aae5d250830a', 0, b'0', 212121, b'0', b'0', b'0', b'0', b'0', b'0', '2021-06-19 23:38:34', 'NDDONG', '2021-06-20 02:03:36', 1, b'0', b'0'),
	('fa8015b8-fbda-46ae-adff-776802e45cce', 'test5', '423d5b84-2191-6cce-df3d-c9e9e9038fe2', '541c96a6-4e24-27fe-6610-dde5fda516a2', '26021185-77af-263c-842a-acc8fc2f00af', 2, b'0', 343242, b'0', b'0', b'0', b'0', b'0', b'0', '2021-06-20 00:04:38', 'NDDONG', NULL, 1, b'0', b'0');
/*!40000 ALTER TABLE `fee` ENABLE KEYS */;

-- Dumping structure for table emis.feegroup
CREATE TABLE IF NOT EXISTS `feegroup` (
  `FeeGroupId` char(36) NOT NULL DEFAULT '' COMMENT 'Kho? ch?nh',
  `FeeGroupName` varchar(255) NOT NULL DEFAULT '' COMMENT 'T?n nh?m kho?n thu',
  `CreatedDate` datetime DEFAULT NULL COMMENT 'Ng?y t?o b?n ghi',
  `CreatedBy` varchar(100) DEFAULT NULL COMMENT 'Ngu?i t?o b?n ghi',
  `ParentId` char(36) DEFAULT NULL COMMENT 'Id c?a nh?m  kho?n thu cha',
  `ModifiedDate` datetime DEFAULT NULL COMMENT 'Ng?y ch?nh s?a g?n nh?t',
  PRIMARY KEY (`FeeGroupId`),
  UNIQUE KEY `UK_FeeGroup_FeeGroupId` (`FeeGroupId`),
  KEY `IDX_FeeGroup_FeeGroupName` (`FeeGroupName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=819 COMMENT='Nh?m kho?n thu';

-- Dumping data for table emis.feegroup: ~6 rows (approximately)
/*!40000 ALTER TABLE `feegroup` DISABLE KEYS */;
INSERT INTO `feegroup` (`FeeGroupId`, `FeeGroupName`, `CreatedDate`, `CreatedBy`, `ParentId`, `ModifiedDate`) VALUES
	('3541ff76-58f0-6d1a-e836-63d5d5eff719', 'Ăn uống', '1970-01-01 00:01:22', 'Araceli Kingsley', '13a507d0-342d-6292-6de3-2ceaa9cf3765', '1995-05-28 12:41:28'),
	('39446ba3-3071-7af6-a5a9-deaf32c96293', 'Học tập', NULL, NULL, '6e0dc48e-3eac-6143-9b66-a58ab8ff47ca', '2003-05-01 11:43:40'),
	('423d5b84-2191-6cce-df3d-c9e9e9038fe2', 'Cơ sở vật chất', '1981-10-05 03:27:54', 'Althea Heath', '1949dae3-4d44-217e-9c66-a58ab8ff47ca', '2018-07-15 00:28:59'),
	('447816de-6069-15bf-de3d-c9e9e9038fe2', 'Đồng phục', '1975-12-04 07:55:17', 'Trent Dobbins', '1f60e54f-196f-45f3-5498-ae38c5379e4b', NULL),
	('71952621-23c8-61d2-d0eb-e423f1575e00', 'Phí phát sinh', '2011-04-23 01:14:43', 'Brett Abney', '6827e1c0-5b98-6d19-831b-27d9d367aeb0', '1976-07-22 17:34:32'),
	('79aca385-65e3-1ebe-f488-479bce9b28fc', 'Hoạt động', '1994-03-30 12:14:22', 'Kim Charlton', '3650c04e-62b1-6908-5598-ae38c5379e4b', '2006-09-08 19:38:31');
/*!40000 ALTER TABLE `feegroup` ENABLE KEYS */;

-- Dumping structure for table emis.feerange
CREATE TABLE IF NOT EXISTS `feerange` (
  `FeeRangeId` char(36) NOT NULL COMMENT 'Kho? ch?nh ph?m vi thu',
  `FeeRangeName` varchar(255) NOT NULL COMMENT 'T?n ph?m vi thu',
  `ParentId` char(36) DEFAULT NULL COMMENT 'ID cha c?a ph?m vi thu',
  `CreatedDate` datetime DEFAULT NULL COMMENT 'Ng?y t?o',
  `CreatedBy` varchar(255) DEFAULT NULL COMMENT 'Ngu?i t?o',
  `ModifiedDate` datetime DEFAULT NULL COMMENT 'Ng?y ch?nh s?a g?n nh?t',
  PRIMARY KEY (`FeeRangeId`),
  UNIQUE KEY `UK_FeeRange_FeeRangeId` (`FeeRangeId`),
  UNIQUE KEY `IDX_FeeRange_FeeRangeName` (`FeeRangeName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=2730 COMMENT='B?ng d? li?u Ph?m vi thu ';

-- Dumping data for table emis.feerange: ~6 rows (approximately)
/*!40000 ALTER TABLE `feerange` DISABLE KEYS */;
INSERT INTO `feerange` (`FeeRangeId`, `FeeRangeName`, `ParentId`, `CreatedDate`, `CreatedBy`, `ModifiedDate`) VALUES
	('3b880afd-77ba-69c9-6510-dde5fda516a2', 'Nội bộ giáo viên', '6528b15d-6674-724f-79a4-4b24de418577', '1971-08-15 15:02:07', 'Carina Summers', '1998-10-20 10:59:30'),
	('4f610a3d-21c1-4b2b-c4fe-7f9a08424f7b', 'Lớp', '34e2b4cc-3758-293d-7aa4-4b24de418577', '1970-01-01 00:00:04', 'Dina Dykes', '1975-12-24 11:54:46'),
	('4fe5ee09-2c89-580a-dc49-fe4bedd9e894', 'Cá nhân', '30007451-29ff-4fe4-3707-70859f4ff30d', '1985-03-01 08:33:08', 'Rocky Souza', '2017-09-19 04:40:17'),
	('541c96a6-4e24-27fe-6610-dde5fda516a2', 'Khoa', '2000637a-2a69-2e7e-a135-f63bd3f197bd', '2008-07-13 07:52:14', 'Joella Oconnell', '2017-04-21 03:20:55'),
	('61e3cc06-6237-222a-7e5b-5b97e23db0bb', 'Toàn trường', '27f91d6c-14b1-6c74-92ef-c9d5c2d91e91', '1970-01-01 01:40:13', 'Jed Feliciano', '1970-01-01 00:00:03'),
	('7461553a-1f2b-56a6-e8c0-f32a102323e6', 'Khối', '3e39129b-279f-623f-88ea-778aee59fea3', '1970-01-01 00:00:02', 'Abe Sims', '1984-01-27 22:53:10');
/*!40000 ALTER TABLE `feerange` ENABLE KEYS */;

-- Dumping structure for table emis.unitfee
CREATE TABLE IF NOT EXISTS `unitfee` (
  `UnitFeeId` char(36) NOT NULL COMMENT 'Kh?a ch?nh don v? thu',
  `UnitFeeName` varchar(255) DEFAULT NULL COMMENT 'T?n don v? thu',
  `CreatedDate` datetime DEFAULT NULL COMMENT 'Ng?y t?o b?n ghi',
  `CreatedBy` varchar(100) DEFAULT NULL COMMENT 'Ngu?i t?o b?ng ghi',
  `ModifiedDate` datetime DEFAULT NULL COMMENT 'Ng?y s?a b?n ghi g?n nh?t ',
  PRIMARY KEY (`UnitFeeId`),
  UNIQUE KEY `UK_UnitAmountFee_UnitFeeId` (`UnitFeeId`),
  UNIQUE KEY `IDX_UnitAmountFee_UnitName` (`UnitFeeName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=4096 COMMENT='?on v? m?c kho?n thu';

-- Dumping data for table emis.unitfee: ~4 rows (approximately)
/*!40000 ALTER TABLE `unitfee` DISABLE KEYS */;
INSERT INTO `unitfee` (`UnitFeeId`, `UnitFeeName`, `CreatedDate`, `CreatedBy`, `ModifiedDate`) VALUES
	('26021185-77af-263c-842a-acc8fc2f00af', 'Quý', '1971-09-24 14:39:55', 'Arthur Glover', '1991-03-18 19:26:06'),
	('2b031b59-5276-589c-9d75-2a7ae1c799c8', 'Năm', '2016-03-10 04:14:28', 'Judi Herron', '1989-04-05 19:13:23'),
	('427b1814-60ed-47cf-edb5-aae5d250830a', 'Tháng', '1984-05-26 07:07:36', 'Lottie Almanza', '1978-03-17 15:23:52'),
	('6118a7ff-742b-25db-a9c1-8e252c39bb73', 'Kỳ học', '1970-01-01 00:09:30', 'Takisha Hagan', '1996-10-27 08:01:32');
/*!40000 ALTER TABLE `unitfee` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
