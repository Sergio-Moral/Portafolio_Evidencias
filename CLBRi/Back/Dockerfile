FROM maven:3.9.4-amazoncorretto-21 AS build
WORKDIR /app
COPY pom.xml .
COPY src ./src

RUN mvn clean package -DskipTests

FROM openjdk:22-jdk-slim-buster

WORKDIR /app

COPY --from=build /app/target/quarkus-app/lib/ /app/lib/
COPY --from=build /app/target/quarkus-app/*.jar /app/
COPY --from=build /app/target/quarkus-app/app /app/app/
COPY --from=build /app/target/quarkus-app/quarkus /app/quarkus/

COPY src/main/resources/clbri-1cf3d-firebase-adminsdk-fbsvc-c01f0b174d.json /app/src/main/resources/
COPY src/main/resources/ecommerce-chidori-firebase-adminsdk-fbsvc-cfa8f6fd26.json /app/src/main/resources/

EXPOSE 8080

CMD ["java", "-jar", "quarkus-run.jar"]