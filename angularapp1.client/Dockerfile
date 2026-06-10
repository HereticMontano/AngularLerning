# Etapa 1: Construcción de Angular
FROM node:20 AS build
WORKDIR /app


COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build --configuration=production

# Etapa 2: Servidor Nginx
FROM nginx:alpine
# Copiamos la configuración personalizada de Nginx
COPY nginx.conf /etc/nginx/conf.d/default.conf
# Copiamos los archivos compilados de Angular (ajusta la ruta si es necesario según tu angular.json)
COPY --from=build /app/dist/angularapp1.client/browser /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]