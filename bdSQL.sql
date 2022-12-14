/*CREATE DATABASE TV Shows*/
CREATE DATABASE TvShows;

USE TvShows;

CREATE TABLE TvShow(
	id_tv_show INT PRIMARY KEY IDENTITY(1, 1),
	title VARCHAR(50) NOT NULL,
	show_description VARCHAR(1500) NOT NULL,
	show_status VARCHAR(50) NOT NULL,
	poster VARCHAR(300) NOT NULL
);

CREATE TABLE Episodes(
	id_episode INT PRIMARY KEY IDENTITY(1, 1),
	id_tv_show INT FOREIGN KEY REFERENCES TvShow ON DELETE CASCADE,
	title VARCHAR(50) NOT NULL,
	duration INT NOT NULL,
	season INT NOT NULL,
	episode_numb INT NOT NULL,
	air_date DATE NOT NULL
);

CREATE TABLE Actors(
	id_actor INT PRIMARY KEY IDENTITY(1, 1),
	actor_name VARCHAR(100) NOT NULL,
	age TINYINT Not NULL
);

CREATE TABLE Characters(
	id_character INT PRIMARY KEY IDENTITY(1, 1),
	id_actor INT FOREIGN KEY REFERENCES Actors ON DELETE CASCADE,
	id_tv_show INT FOREIGN KEY REFERENCES TvShow ON DELETE CASCADE,
	character_name VARCHAR(100) NOT NULL
);

CREATE TABLE Genres(
	id_genre INT PRIMARY KEY IDENTITY(1, 1),
	title VARCHAR(100) NOT NULL
);

CREATE TABLE ListGenres(
	id_list_genres INT PRIMARY KEY IDENTITY(1, 1),
	id_genre INT FOREIGN KEY REFERENCES Genres ON DELETE CASCADE,
	id_tv_show INT FOREIGN KEY REFERENCES TvShow ON DELETE CASCADE
);

CREATE TABLE Users(
	id_user INT PRIMARY KEY IDENTITY(1, 1),
	nickname VARCHAR(200) NOT NULL,
	email VARCHAR(200) NOT NULL,
	pwd VARCHAR(800) NOT NULL
);

CREATE TABLE Favorites(
	id_favorites INT PRIMARY KEY IDENTITY(1, 1),
	id_user INT FOREIGN KEY REFERENCES Users ON DELETE CASCADE,
	id_tv_show INT FOREIGN KEY REFERENCES TvShow ON DELETE CASCADE
);