FROM node:latest as build
WORKDIR /app
COPY ["LT_Frontend/package.json", "LT_Frontend/"]
RUN npm install
COPY . .
CMD ["npm", "run", "dev"]
EXPOSE 5173
