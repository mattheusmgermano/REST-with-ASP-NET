FROM mysql:5.7.22
EXPOSE 3306
COPY ./REST-with-ASP-NET/db/migrations/ /home/database/
COPY ./REST-with-ASP-NET/db/dataset/ /home/database/
COPY ./REST-with-ASP-NET/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh