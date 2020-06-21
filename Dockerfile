FROM php:7.1-apache

RUN requirements="nano cron mysql-client-5.5 libpng12-dev libmcrypt-dev libmcrypt4 libcurl3-dev libxml2-dev libfreetype6 libjpeg62-turbo libpng12-dev libfreetype6-dev libjpeg62-turbo-dev" \
    && apt-get update && apt-get install -y --no-install-recommends $requirements \
    && rm -rf /var/lib/apt/lists/* \
    && docker-php-ext-install pdo pdo_mysql \
    && docker-php-ext-configure gd --with-freetype-dir=/usr/include/ --with-jpeg-dir=/usr/include/ \
    && docker-php-ext-install gd \
    && docker-php-ext-install mcrypt \
    && docker-php-ext-install mbstring \
    && docker-php-ext-install soap \
    && docker-php-ext-install mysqli \
    && requirementsToRemove="libpng12-dev libmcrypt-dev libcurl3-dev libxml2-dev libpng12-dev libfreetype6-dev libjpeg62-turbo-dev" \
    && apt-get purge --auto-remove -y $requirementsToRemove

RUN openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout /etc/ssl/server.key -out /etc/ssl/server.crt -subj "/C=FR/ST=Nord/L=Lille/O=Effid/OU=IT/CN=effid.local"

COPY effid.conf /etc/apache2/sites-enabled/effid.conf
RUN a2enmod rewrite
RUN a2ensite default-ssl
RUN a2enmod ssl

COPY ./php.ini /usr/local/etc/php/

EXPOSE 80
EXPOSE 443
