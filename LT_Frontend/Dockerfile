FROM node:latest
WORKDIR /app
COPY package.json ./
RUN npm install -g
COPY ./ ./
EXPOSE 5173
CMD ["npm", "run", "dev"]

