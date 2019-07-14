CREATE TABLE articulocientifico(
  articulocientifico_id BIGINT(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  autor_id BIGINT(20) UNSIGNED NOT NULL,
  formato_id BIGINT(20) UNSIGNED NOT NULL,
  titulo VARCHAR(50) NOT NULL,
  resumen VARCHAR(50) NOT NULL,
  contenido VARCHAR(50) NOT NULL,
  created_at_envio DATETIME NOT NULL,
  created_at_aceptacion DATETIME NOT NULL,
  created_at_publicacion DATETIME NOT NULL,
  PRIMARY KEY(articulocientifico_id),
  UNIQUE INDEX UQ_articulocientifico_formato_id_autor_id(formato_id,autor_id),
  INDEX IX_articulocientifico_autor_id(autor_id),
  INDEX IX_articulocientifico_formato_id(formato_id),  
  CONSTRAINT FK_articulocientifico_autor_id FOREIGN KEY(autor_id) REFERENCES autor(autor_id)

) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;