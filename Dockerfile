FROM httpd:2.4.43-alpine
EXPOSE 8080
EXPOSE 80
EXPOSE 443

# RUN apt-get update && apt-get install -y zlib1g-dev openssl
# RUN docker-php-ext-install mysqli pdo pdo_mysql zip mbstring
# RUN apk add acf-openssl

# RUN openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout /etc/ssl/server.key -out /etc/ssl/server.crt -subj "/C=FR/ST=Nord/L=Lille/O=Effid/OU=IT/CN=effid.local"

# RUN a2enmod rewrite
# RUN a2ensite default-ssl
# RUN a2enmod ssl

COPY httpd.conf /usr/local/apache2/conf/httpd.conf
COPY src/ /usr/local/apache2/htdocs/
