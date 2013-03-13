DROP DATABASE IF EXISTS blog;
CREATE DATABASE blog;
USE blog;
CREATE TABLE `authors`
(
	username VARCHAR(255) NOT NULL UNIQUE,
	id INT NOT NULL AUTO_INCREMENT,
	PRIMARY KEY (id)
);

CREATE TABLE posts
(
	id INT NOT NULL AUTO_INCREMENT,
	title VARCHAR(255) NOT NULL,
	nickname VARCHAR(255) NOT NULL,
	body TEXT NOT NULL,
	published_dateTime DATETIME NOT NULL,
	authorId INT NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (authorId) REFERENCES `authors`(id)
);


-- posts.Add(new Post("First", "first post", new DateTime(34, 4, 23), "John Doe"));
--             posts.Add(new Post("Second", "second post", new DateTime(98, 7, 25), "John Doe"));
--             posts.Add(new Post("Third", "third post", new DateTime(34, 6, 23), "John Doe"));
--             posts.Add(new Post("Fourth", "fourth post", new DateTime(53, 7, 13), "Some Guy"));
--             posts.Add(new Post("Fifth", "fifth post", new DateTime(26, 6, 27), "John Doe"));

INSERT INTO `authors` 
(username)
VALUES
('John Doe');

INSERT INTO `authors` 
(username)
VALUES
('Some Guy');

INSERT INTO posts
(title, nickname, body, published_datetime, authorId)
VALUES
('First', 'first', 'first post', '2000-5-7 12:30:30', '1');

INSERT INTO posts
(title, nickname, body, published_datetime, authorId)
VALUES
('Second', 'second', 'second post', '2001-5-7 12:30:30', '1');

INSERT INTO posts
(title, nickname, body, published_datetime, authorId)
VALUES
('Third', 'third', 'third post', '2001-5-7 12:30:30', '1');

INSERT INTO posts
(title, nickname, body, published_datetime, authorId)
VALUES
('Fourth', 'fourth', 'fourth post', '2001-5-7 12:30:30', '2');

INSERT INTO posts
(title, nickname, body, published_datetime, authorId)
VALUES
('Fifth', 'fifth', 'fifth post', '2004-5-7 12:30:30', '1');

SELECT * FROM `authors`;
SELECT * FROM posts;
