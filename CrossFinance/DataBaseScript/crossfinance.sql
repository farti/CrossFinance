-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema crossfinance
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema crossfinance
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `crossfinance` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `crossfinance` ;

-- -----------------------------------------------------
-- Table `crossfinance`.`address`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `crossfinance`.`address` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `StreetName` VARCHAR(45) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
  `StreetNumber` VARCHAR(45) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
  `FlatNumber` VARCHAR(45) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
  `PostCode` VARCHAR(45) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
  `PostOfficeCity` VARCHAR(45) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
  `CorrespondenceStreetName` VARCHAR(45) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
  `CorrespondenceStreetnumber` VARCHAR(45) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
  `CorrespondenceFlatNumber` VARCHAR(45) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
  `CorrespondencePostCode` VARCHAR(45) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
  `CorrespondencePostOfficeCity` VARCHAR(45) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_polish_ci;


-- -----------------------------------------------------
-- Table `crossfinance`.`financialstate`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `crossfinance`.`financialstate` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `OutstandingLiabilites` DECIMAL(13,4) NULL DEFAULT NULL,
  `Interests` DECIMAL(13,4) NULL DEFAULT NULL,
  `PenaltyInterests` DECIMAL(13,4) NULL DEFAULT NULL,
  `Fees` DECIMAL(13,4) NULL DEFAULT NULL,
  `CourtFees` DECIMAL(13,4) NULL DEFAULT NULL,
  `RepresentationCourtFees` DECIMAL(13,4) NULL DEFAULT NULL,
  `VindicationCosts` DECIMAL(13,4) NULL DEFAULT NULL,
  `RepresentationVindicationCosts` DECIMAL(13,4) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_polish_ci;


-- -----------------------------------------------------
-- Table `crossfinance`.`person`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `crossfinance`.`person` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(45) NULL DEFAULT NULL,
  `SecondName` VARCHAR(45) NULL DEFAULT NULL,
  `Surname` VARCHAR(45) NULL DEFAULT NULL,
  `NationalIdentificationNumber` VARCHAR(45) NULL DEFAULT NULL,
  `AddressId` INT(11) NULL DEFAULT NULL,
  `PhoneNumber` VARCHAR(45) NULL DEFAULT NULL,
  `PhoneNumber2` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC),
  INDEX `fk_person_address_idx` (`AddressId` ASC),
  CONSTRAINT `fk_person_address`
    FOREIGN KEY (`AddressId`)
    REFERENCES `crossfinance`.`address` (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_polish_ci;


-- -----------------------------------------------------
-- Table `crossfinance`.`agreement`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `crossfinance`.`agreement` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Number` VARCHAR(45) NULL DEFAULT NULL,
  `PersonId` INT(11) NOT NULL,
  `FinancialStateId` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC),
  INDEX `fk_agreement_financialstate_idx` (`FinancialStateId` ASC),
  INDEX `fk_agreement_person_idx` (`PersonId` ASC),
  CONSTRAINT `fk_agreement_financialstate`
    FOREIGN KEY (`FinancialStateId`)
    REFERENCES `crossfinance`.`financialstate` (`Id`),
  CONSTRAINT `fk_agreement_person`
    FOREIGN KEY (`PersonId`)
    REFERENCES `crossfinance`.`person` (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_polish_ci;

USE `crossfinance` ;

-- -----------------------------------------------------
-- procedure sp_InsertData
-- -----------------------------------------------------

DELIMITER $$
USE `crossfinance`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertData`(

IN StreetName VARCHAR(45),
IN StreetNumber VARCHAR(45),
IN FlatNumber VARCHAR(45),
IN PostCode VARCHAR(45),
IN PostOfficeCity VARCHAR(45),
IN CorrespondenceStreetName VARCHAR(45),
IN CorrespondenceStreetnumber VARCHAR(45),
IN CorrespondenceFlatNumber VARCHAR(45),
IN CorrespondencePostCode VARCHAR(45),
IN CorrespondencePostOfficeCity VARCHAR(45),

IN FirstName VARCHAR(45),
IN SecondName VARCHAR(45),
IN Surname VARCHAR(45),
IN NationalIdentificationNumber VARCHAR(45),
IN AddressId INT(11),
IN PhoneNumber VARCHAR(45),
IN PhoneNumber2 VARCHAR(45),

IN OutstandingLiabilites DECIMAL(13,4), 
IN Interests DECIMAL(13,4), 
IN PenaltyInterests DECIMAL(13,4), 
IN Fees DECIMAL(13,4), 
IN CourtFees DECIMAL(13,4), 
IN RepresentationCourtFees DECIMAL(13,4), 
IN VindicationCosts DECIMAL(13,4), 
IN RepresentationVindicationCosts DECIMAL(13,4),

IN Number VARCHAR(45),
IN PersonID INT(11),
IN FinancialStateId INT(11)

)
BEGIN

INSERT INTO address(
StreetName, StreetNumber,FlatNumber,PostCode,PostOfficeCity,CorrespondenceStreetName,CorrespondenceStreetnumber,CorrespondenceFlatNumber,CorrespondencePostCode,CorrespondencePostOfficeCity
)
VALUES (
StreetName, StreetNumber,FlatNumber,PostCode,PostOfficeCity,CorrespondenceStreetName,CorrespondenceStreetnumber,CorrespondenceFlatNumber,CorrespondencePostCode,CorrespondencePostOfficeCity
); 
select last_insert_id() into @mysql_variable_addressId;

INSERT INTO person(
FirstName, SecondName, Surname, NationalIdentificationNumber, AddressId, PhoneNumber, PhoneNumber2
) 
VALUES(
FirstName, SecondName, Surname, NationalIdentificationNumber, @mysql_variable_addressId, PhoneNumber, PhoneNumber2
);
select last_insert_id() into @mysql_variable_personId; 

INSERT INTO financialstate(
OutstandingLiabilites, Interests, PenaltyInterests, Fees, CourtFees, RepresentationCourtFees, VindicationCosts, RepresentationVindicationCosts
)
VALUES (
OutstandingLiabilites, Interests, PenaltyInterests, Fees, CourtFees, RepresentationCourtFees, VindicationCosts, RepresentationVindicationCosts
);
select last_insert_id() into @mysql_variable_financialstated; 

INSERT INTO agreement(
Number, PersonId, FinancialStateId
)
VALUES (
Number, @mysql_variable_personId, @mysql_variable_financialstated
);

END$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
