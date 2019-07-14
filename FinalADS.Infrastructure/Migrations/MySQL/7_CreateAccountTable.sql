﻿CREATE TABLE account(
  account_id BIGINT(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  number VARCHAR(50) NOT NULL,
  balance DECIMAL(10,2) NOT NULL,
  locked BIT NOT NULL,
  customer_id BIGINT UNSIGNED NOT NULL,
  created_at_utc DATETIME NOT NULL,
  updated_at_utc DATETIME NOT NULL,
  PRIMARY KEY(account_id),
  INDEX IX_account_customer_id(customer_id),
  UNIQUE INDEX UQ_account_number(number)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

