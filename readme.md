# Meteogalicia (Predicciones)
## Resumen

Servicio REST escrito en .NET para recuperar datos de la API de 
[Meteogalicia](https://www.meteogalicia.gal/web/RSS/rssIndex.action?request_locale=es).

## Desarrollo

Se ha implementado una llamada que recupera la predicción del día de hoy y los dos siguientes. En la respuesta 
facilita los siguientes datos:

- Cielo (mañana, tarde, noche)
	- Se deberá devolver un string indicando la situación. Por ejemplo: "Despejado", "Cubierto", "Chubasco", 
"Llovizna"...
- Porcentaje de lluvia (mañana, tarde, noche)
- Temperatura Máxima (tMax)
- Temperatura mínima (tMin)

[http://[dominio]:5046/api/observacion/[idMunicipio]]()

## Swagger y OpenAPI

Se puede acceder a la definición de las llamadas y esquemas a través de los siguientes enlaces:
- Interfaz Swagger $\rightarrow$ [http://[dominio]:5046/swagger/index.html]()
- Esquema OpenAPI $\rightarrow$ [http://[dominio]:5046/swagger/v1/swagger.json]()
