CREATE DATABASE blog_system;
USE blog_system;

CREATE TABLE [images]
	(
	id INT IDENTITY,
	[path] VARCHAR(255),
	
	CONSTRAINT pk_image_id PRIMARY KEY(id)
	);

CREATE TABLE [user_account]
	(
	id INT IDENTITY,
	full_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	gender BIT NOT NULL,
	date_of_birth SMALLDATETIME NOT NULL,
	
	CONSTRAINT pk_user_account_id PRIMARY KEY(id)
	);
	
CREATE TABLE [user_login]
	(
	id INT IDENTITY,
	user_id INT NOT NULL,
	login_name VARCHAR(100) NOT NULL,
	password_hash VARCHAR(255) NOT NULL,
	email_address VARCHAR(150) NOT NULL,
	status BIT NOT NULL,
	
	CONSTRAINT pk_user_login_id PRIMARY KEY(id),
	CONSTRAINT fk_user_account_user_login_id FOREIGN KEY(user_id) 
		REFERENCES [user_account](id)
	);
	
CREATE TABLE [posts]
	(
	id INT IDENTITY,
	user_login_id INT NOT NULL,
	title VARCHAR(100) NOT NULL,
	content VARCHAR(255),
	status BIT NOT NULL,
	create_at SMALLDATETIME NOT NULL,
	image_id INT NULL,
	
	CONSTRAINT pk_post_id PRIMARY KEY(id),
	CONSTRAINT fk_user_login_post_id FOREIGN KEY(user_login_id) 
		REFERENCES [user_login](id),
	CONSTRAINT fk_image_post_id FOREIGN KEY(image_id) 
		REFERENCES [images](id)
	);
	
CREATE TABLE [comments]
	(
	id INT IDENTITY,
	post_id INT NOT NULL,
	user_login_id INT NOT NULL,
	content VARCHAR(500) NOT NULL,
	status BIT NOT NULL,
	create_at SMALLDATETIME NOT NULL,
	response_id INT NULL,
	
	CONSTRAINT pk_comment_id PRIMARY KEY(id),
	CONSTRAINT fk_post_comment_id FOREIGN KEY(post_id) 
		REFERENCES [posts](id),
	CONSTRAINT fk_user_login_comment_id FOREIGN KEY(user_login_id) 
		REFERENCES [user_login](id),
 	);
 	
 ALTER TABLE [comments] ADD CONSTRAINT fk_comment_id 
 	FOREIGN KEY(response_id) REFERENCES [comments](id);