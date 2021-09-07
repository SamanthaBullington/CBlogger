CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE blogs(  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    title varchar(255) comment 'blog title',
    body varchar(255) comment 'blog description',
    imgUrl varchar(255) comment 'blog image',
    published bit comment 'blog published',
    creatorId VARCHAR(255) COMMENT 'creatorId',
    FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 comment '';

CREATE TABLE comments(  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    body varchar(255) comment 'comment description',
    creatorId VARCHAR(255) COMMENT 'creatorId',
    blog INT COMMENT 'blog id',
    FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
    FOREIGN KEY (blog) REFERENCES blogs(id) ON DELETE CASCADE
) default charset utf8 comment '';