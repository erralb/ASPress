
INSERT INTO `roles` (`name`,`reference`,`permissions`) VALUES ('Administrator','admin',NULL);
INSERT INTO `roles` (`name`,`reference`,`permissions`) VALUES ('User','user',NULL);

INSERT INTO `users` (`username`,`password`,`email`,`name`,`date_created`,`date_last_login`) 
VALUES ('admin','admin','admin@admin.com','Admin',CURRENT_TIMESTAMP,CURRENT_TIMESTAMP);

INSERT INTO `roles_users` (`role_id`,`user_id`) VALUES (1,1);

INSERT INTO `posts` (`title`,`url`,`content`,`summary`,`type`,`status`,`visibility`,`password`,`author_id`,`date_created`,`date_modified`,`date_publish`) 
VALUES ('Hello World','hello-world','content goes here','My first post','post','published','public',NULL,1,CURRENT_TIMESTAMP,NULL,CURRENT_TIMESTAMP);
