# syntax=docker/dockerfile:1

FROM amd64/golang:1.19-alpine as builder
WORKDIR /app
COPY go.mod ./
COPY go.sum ./
RUN go mod download
COPY *.go ./
RUN go build -o /wisdomduck

FROM amd64/alpine:latest as production
WORKDIR /app
COPY --from=builder /wisdomduck .
COPY ./duck ./duck

EXPOSE 5500

CMD [ "./wisdomduck" ]