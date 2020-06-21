FROM php:7.1-apache

RUN requirements="nano cron libpng12-dev libmcrypt-dev libmcrypt4 libcurl3-dev libxml2-dev libfreetype6 libjpeg62-turbo libfreetype6-dev libjpeg62-turbo-dev"
RUN apt-get update && apt-get install -y --no-install-recommends $requirements
RUN docker-php-ext-install mysqli pdo pdo_mysql zip mbstring mcrypt

RUN openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout /etc/ssl/server.key -out /etc/ssl/server.crt -subj "/C=FR/ST=Nord/L=Lille/O=Effid/OU=IT/CN=effid.local"

COPY effid.conf /etc/apache2/sites-enabled/effid.conf
COPY src/ /var/www/html/

RUN a2enmod rewrite
RUN a2ensite default-ssl
RUN a2enmod ssl

EXPOSE 80
EXPOSE 443
