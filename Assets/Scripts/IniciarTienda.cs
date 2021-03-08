using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarTienda : MonoBehaviour
{
    
    public List<Preguntas> preguntas;

    public List<TipoAlimento> RellenarCategorias()
    {
        //Rellenamos los tipos de alimentos / Categorias.
        List<TipoAlimento> lista = new List<TipoAlimento>();
        lista.Add(new TipoAlimento()
        {
            ID=1,
            Nombre ="Cereales, cereales integrales y patatas.",
            Descripcion ="Ricos en carbohidratos complejos.",
            Frecuencia ="6 o más RACIONES AL DÍA. Mejor si los cereales son integrales"
        });
        lista.Add(new TipoAlimento()
        {
            ID=2,
            Nombre ="Frutas.",
            Descripcion = @"Ricos en agua, hidratos de carbono simples, fibra dietética y vitaminas.",
            Frecuencia = @"2 y 3 RACIONES o más AL DÍA
                Al menos una ración debe ser en crudo"
        });
        lista.Add(new TipoAlimento()
        {
            ID=3,
            Nombre ="Verduras y hortalizas.",
            Descripcion ="Ricos en agua y fibra.",
            Frecuencia = @"SE RECOMIENDAN 2-3 RACIONES o más AL DÍA
                Se recomienda que una sea un cítrico y no sustituir la fruta entera por zumos de forma habitual."
        });
        lista.Add(new TipoAlimento()
        {
            ID=4,
            Nombre ="Leche y derivados lácteos.",
            Descripcion = "Contiene casi todos los nutrientes necesarios en cantidades apreciables. Excelente fuente de proteínas de alto valor biológico.",
            Frecuencia = @"3 RACIONES AL DÍA"
        });
        lista.Add(new TipoAlimento()
        {
            ID=5,
            Nombre ="Carnes y derivados.",
            Descripcion = "Contiene proteínas de alto valor biológico.",
            Frecuencia = @"3 RACIONES POR SEMANA."
        });
        lista.Add(new TipoAlimento()
        {
            ID=6,
            Nombre ="Pescados y mariscos.",
            Descripcion = @"Gran contenido de agua, proteínas de alto valor biológico y de elevada digestibilidad. En mariscos destaca su contenido en minerales y vitaminas.",
            Frecuencia = @"3-4 RACIONES POR SEMANA
                Alternando el consumo de pescados grasos, semigrasos y blancos y mariscos."
        });
        lista.Add(new TipoAlimento()
        {
            ID=7,
            Nombre ="Huevos y ovoproductos.",
            Descripcion = @"Alto valor nutricional global, rico en aminoácidos esenciales, ácidos grasos, vitaminas y minerales.",
            Frecuencia = @"3 RACIONES POR SEMANA."
        });
        lista.Add(new TipoAlimento()
        {
            ID=8,
            Nombre ="Legumbres.",
            Descripcion = @"Alto contenido de hidratos de carbono complejos y fibra.",
            Frecuencia = @"3-4 RACIONES POR SEMANA"
        });
        lista.Add(new TipoAlimento()
        {
            ID=9,
            Nombre ="Frutos secos.",
            Descripcion = @"Elevado contenido en proteínas y grasas 'buenas'. fuente de fibra, destaca su contenido en minerales.",
            Frecuencia = @"2-4 RACIONES POR SEMANA
                Una ración = 25 g aprox. de frutos secos pelados. 
                Se recomienda consumirlos crudos o ligeramente tostados, sin azúcar, sal o grasa añadida."
        });
        lista.Add(new TipoAlimento()
        {
            ID=10,
            Nombre ="Aceite de oliva .",
            Descripcion = @"Aporta sobre todo ácido oleico (que es una grasa monoinsaturadas, 'buena') y muchos componentes minoritarios de gran valor nutricional como los .",
            Frecuencia = @"SE RECOMIENDAN 3-4 RACIONES DIARIAS."
        });
        lista.Add(new TipoAlimento()
        {
            ID=11,
            Nombre ="Grasas, dulces y embutidos.",
            Descripcion = @"Alimentos ricos en grasas saturadas (mantequillas, margarinas o embutidos grasos.
                La miel, el azúcar de mesa o la bollería industrial contienen azúcares, que son hidratos de carbono simples de absorción rápida.",
            Frecuencia = @"CONSUMO MODERADO Y OCASIONAL"
        });
        lista.Add(new TipoAlimento()
        {
            ID=12,
            Nombre ="Grasas, dulces y embutidos.",
            Descripcion = @"Alimentos ricos en grasas saturadas (mantequillas, margarinas o embutidos grasos.
                La miel, el azúcar de mesa o la bollería industrial contienen azúcares, que son hidratos de carbono simples de absorción rápida.",
            Frecuencia = @"CONSUMO MODERADO Y OCASIONAL"
        });

        return lista;
    }

    public List<Alimento> RellenarAlimentos()
    {
        //Rellenamos los tipos de alimentos / Categorias.

        //---------------------
        // Puesto de frutas y verduras
        //---------------------

        var lista = new List<Alimento>();
        lista.Add(new Alimento()
        {
            ID=1,
            IDTipoAlimento = 2,
            Nombre = "Manzana",
            Unidades = 2,
            Puntuacion = 3,
            Observaciones = @"En Andalucía apenas se produce.",
            ImageSource = "Frutas/manzana",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=2,
            IDTipoAlimento = 2,
            Nombre = "Naranja",
            Unidades = 2,
            Puntuacion = 4,
            Observaciones = string.Empty,
            ImageSource = "Frutas/naranja",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=3,
            IDTipoAlimento = 2,
            Nombre = "Fresas",
            Unidades = 2,
            Puntuacion = 4,
            Observaciones = @"Presentación en barqueta.",
            ImageSource = "Frutas/fresas",
            IsAndaluz = true
        });
        lista.Add(new Alimento()  
        {
            ID=4,
            IDTipoAlimento = 2,
            Nombre = "Kiwi", // PONÍA FRESA! PERO CREO QUE ES KIWI
            Unidades = 2,
            Puntuacion = 3,
            Observaciones = @"En Andalucía no se produce.",
            ImageSource = "Frutas/kiwi",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=5,
            IDTipoAlimento = 2,
            Nombre = "Platano",
            Unidades = 2,
            Puntuacion = 3,
            Observaciones = @"En Andalucía apenas se produce.",
            ImageSource = "Frutas/platano",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=6,
            IDTipoAlimento = 2,
            Nombre = "Mandarinas",
            Unidades = 2,
            Puntuacion = 4,
            Observaciones = string.Empty,
            ImageSource = "Frutas/mandarina",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=7,
            IDTipoAlimento = 2,
            Nombre = "Pomelo",
            Unidades = 1,
            Puntuacion = 4,
            Observaciones = string.Empty,
            ImageSource = "Frutas/pomelo",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=8,
            IDTipoAlimento = 2,
            Nombre = "Mango",
            Unidades = 2,
            Puntuacion = 4,
            Observaciones = string.Empty,
            ImageSource = "Frutas/mango",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=9,
            IDTipoAlimento = 2,
            Nombre = "Aguacate",
            Unidades = 2,
            Puntuacion = 4,
            Observaciones = string.Empty,
            ImageSource = "Frutas/aguacate",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=10,
            IDTipoAlimento = 3,
            Nombre = "Tomate",
            Unidades = 2,
            Puntuacion = 4,
            Observaciones = string.Empty,
            ImageSource = "Frutas/tomate",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=11,
            IDTipoAlimento = 3,
            Nombre = "Cebolla", // ESTABA REPETIDO TOMATE. CREO QUE AQUÍ VA CEBOLLA
            Unidades = 1,
            Puntuacion = 3,
            Observaciones = string.Empty,
            ImageSource = "Frutas/cebolla",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=12,
            IDTipoAlimento = 3,
            Nombre = "Esparragos",
            Unidades = 1,
            Puntuacion = 4,
            Observaciones = @"Verdes de Huetor Tájar Presentación en manojo",
            ImageSource = "Frutas/esparragos",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=13,
            IDTipoAlimento = 3,
            Nombre = "Zanahoria",
            Unidades = 1,
            Puntuacion = 3,
            Observaciones = @"Verdes de Huetor Tájar Presentación en manojo",
            ImageSource = "Frutas/zanahoria",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=14,
            IDTipoAlimento = 1,
            Nombre = "Patata",
            Unidades = 1,
            Puntuacion = 3,
            Observaciones = @"En Andalucía se producen las extratempranas y tempranas.",
            ImageSource = "Frutas/patatas",
            IsAndaluz = false
        });

        lista.Add(new Alimento()
        {
            ID=41,
            IDTipoAlimento = 2,
            Nombre = "Sandia",
            Unidades = 1,
            Puntuacion = 3,
            Observaciones = @"",
            ImageSource = "Frutas/sandia",
            IsAndaluz = false
        });

        lista.Add(new Alimento()
        {
            ID=42,
            IDTipoAlimento = 2,
            Nombre = "Arandanos",
            Unidades = 1,
            Puntuacion = 3,
            Observaciones = @"",
            ImageSource = "Frutas/arandanos",
            IsAndaluz = false
        });



        //CANTIDAD TOTAL 25

        //---------------------
        // Puesto de lácteos
        //---------------------

        lista.Add(new Alimento()
        {
            ID=15,
            IDTipoAlimento = 4,
            Nombre = "Leche",
            Unidades = 2,
            Puntuacion = 4,
            Observaciones = @"Presentación en botella.",
            ImageSource = "Lacteos/leche",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=16,
            IDTipoAlimento = 12,
            Nombre = "Mantequilla",
            Unidades = 2,
            Puntuacion = 1,
            Observaciones = string.Empty,
            ImageSource = "Lacteos/mantequilla",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=17,
            IDTipoAlimento = 4,
            Nombre = "Queso",
            Unidades = 2,
            Puntuacion = 4,
            Observaciones = @"Presentar Un queso fresco y un queso curado.",
            ImageSource = "Lacteos/queso",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=18,
            IDTipoAlimento = 4,
            Nombre = "Yogurt",
            Unidades = 2,
            Puntuacion = 4,
            Observaciones = string.Empty,
            ImageSource = "Lacteos/yogur",
            IsAndaluz = false
        });
        //TOTAL 8

        //---------------------
        // Panadería y bollería
        //---------------------

        lista.Add(new Alimento()
        {
            ID=19,
            IDTipoAlimento = 1,
            Nombre = "Pan",
            Unidades = 4,
            Puntuacion = 4,
            Observaciones = @"menciones a panes típicos andaluces
                - pan de Alfacar, 
                - molletes de Antequera
                - telera cordobesa
                    Hacer preguntas nuevas",
            ImageSource = "Panaderia/pan_1",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=20,
            IDTipoAlimento = 1,
            Nombre = "Bizcocho casero",
            Unidades = 2,
            Puntuacion = 1,
            Observaciones = string.Empty,
            ImageSource = "Panaderia/croisant",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=21,
            IDTipoAlimento = 1,
            Nombre = "Donuts",
            Unidades = 1,
            Puntuacion = 1,
            Observaciones = @"Presentar Un queso fresco y un queso curado.",
             ImageSource = "Panaderia/rosquillas",
             IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=22,
            IDTipoAlimento = 1,
            Nombre = "Galletas",
            Unidades = 1,
            Puntuacion = 1,
            Observaciones = string.Empty,
            ImageSource = "Panaderia/galletas",
            IsAndaluz = false
        });
        //TOTAL 8

        //---------------------
        // Varios
        //---------------------
        lista.Add(new Alimento()
        {
            ID=23,
            IDTipoAlimento = 7,
            Nombre = "Huevo",
            Unidades = 8,
            Puntuacion = 2,
            Observaciones = string.Empty,
            ImageSource = "Varios/huevo",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=24,
            IDTipoAlimento = 11,
            Nombre = "Azucar",
            Unidades = 2,
            Puntuacion = 1,
            Observaciones = @"En Andalucía apenas se produce.
            Cuidado con ella
            Presentación en paquete",
            ImageSource = "Varios/azucar",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=25,
            IDTipoAlimento = 10,
            Nombre = "Aceite de oliva",
            Unidades = 4,
            Puntuacion = 4,
            Observaciones = @"Presentación en botellas.",
            ImageSource = "Varios/aceite de oliva",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=26,
            IDTipoAlimento = 10,
            Nombre = "Aceituna de mesa",
            Unidades = 2,
            Puntuacion = 3,
            Observaciones = @"Presentación en lata o bote.",
            ImageSource = "Varios/aceitunas",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=27,
            IDTipoAlimento = 1,
            Nombre = "Arroz",
            Unidades = 2,
            Puntuacion = 4,
            Observaciones = @"Paquete de arroz.",
            ImageSource = "Varios/arroz_stewart",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=28,
            IDTipoAlimento = 1,
            Nombre = "Arroz desayuno",
            Unidades = 2,
            Puntuacion = 2,
            Observaciones = @"Paquete cereal  de desayuno.",
            ImageSource = "Varios/arroz_stewart",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=29,
            IDTipoAlimento = 1,
            Nombre = "Maíz",
            Unidades = 1,
            Puntuacion = 1,
            Observaciones = @"En Andalucía apenas se produce 1 paquete cereal  de desayuno.",
            ImageSource = "Varios/maiz",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=30,
            IDTipoAlimento = 1,
            Nombre = "Maíz",
            Unidades = 1,
            Puntuacion = 3,
            Observaciones = @"En Andalucía apenas se produce En grano",
            ImageSource = "Varios/maiz",
            IsAndaluz = false
            
        });
        lista.Add(new Alimento()
        {
            ID=31,
            IDTipoAlimento = 8,
            Nombre = "Garbanzo",
            Unidades = 1,
            Puntuacion = 2,
            Observaciones = string.Empty,
            ImageSource = "Varios/garbanzos",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=32,
            IDTipoAlimento = 1,
            Nombre = "Pasta",
            Unidades = 1,
            Puntuacion = 3,
            Observaciones = string.Empty,
            ImageSource = "Varios/pasta",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=33,
            IDTipoAlimento = 1,
            Nombre = "Harina de trigo",
            Unidades = 1,
            Puntuacion = 3,
            Observaciones = string.Empty,
            ImageSource = "Varios/harina",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=34,
            IDTipoAlimento = 9,
            Nombre = "Almendras",
            Unidades = 2,
            Puntuacion = 3,
            Observaciones = string.Empty,
            ImageSource = "Varios/almendras",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=35,
            IDTipoAlimento = 11,
            Nombre = "Miel",
            Unidades = 1,
            Puntuacion = 1,
            Observaciones = string.Empty,
            ImageSource = "Varios/miel",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=36,
            IDTipoAlimento = 2,
            Nombre = "Mermelada",
            Unidades = 1,
            Puntuacion = 1,
            Observaciones = string.Empty,
            ImageSource = "Varios/mermelada",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=37,
            IDTipoAlimento = 5,
            Nombre = "Carne vacuno",
            Unidades = 1,
            Puntuacion = 2,
            Observaciones = string.Empty,
            ImageSource = "Varios/filete",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=38,
            IDTipoAlimento = 5,
            Nombre = "Carne de pollo",
            Unidades = 1,
            Puntuacion = 2,
            Observaciones = string.Empty,
            ImageSource = "Varios/pollo",
            IsAndaluz = false
        });
        lista.Add(new Alimento()
        {
            ID=39,
            IDTipoAlimento = 5,
            Nombre = "Embutido ibérico",
            Unidades = 2,
            Puntuacion = 2,
            Observaciones = string.Empty,
            ImageSource = "Varios/jamon",
            IsAndaluz = true
        });
        lista.Add(new Alimento()
        {
            ID=40,
            IDTipoAlimento = 6,
            Nombre = "Lata de atún o caballa",
            Unidades = 1,
            Puntuacion = 2,
            Observaciones = @"Presentación en bote",
            ImageSource = "Varios/conservas",
            IsAndaluz = false
        });

        return lista;
    }

    public List<Preguntas> RellenarPreguntas()
    {

        var lista = new List<Preguntas>();

        //---------------------
        // Puesto de frutas y verduras
        //---------------------
        // 25 preguntas
        // Tenemos listados Kiwi y Pomelo, pero no hay preguntas para ellos
        // Existen preguntas para sandía (no incluidas aquí), pero no tenemos la fruta

        // MANZANA
        lista.Add(new Preguntas()
        {
            ID=1,
            IDAlimento = 1,
            IDTipoAlimento = 2,
            Pregunta = "Cuando las manzanas se recogen del árbol son siempre de color marrón.",
            Respuesta = false
        });

        lista.Add(new Preguntas()
        {
            ID=2,
            IDAlimento = 1,
            IDTipoAlimento = 2,
            Pregunta = "La manzana es una de las frutas más cultivadas y consumidas del mundo.",
            Respuesta = true
        });

        // NARANJA
        lista.Add(new Preguntas()
        {
            ID=3,
            IDAlimento = 2,
            IDTipoAlimento = 2,
            Pregunta = "Las mandarinas son naranjas que se han quedado pequeñas porque el agricultor no las ha regado bien.",
            Respuesta = false
        });        

        lista.Add(new Preguntas()
        {
            ID=4,
            IDAlimento = 2,
            IDTipoAlimento = 2,
            Pregunta = "Los árabes introdujeron el cultivo de los cítricos en España, no solo en Valencia, también en Andalucía.",
            Respuesta = true
        });        

        // FRESAS
        lista.Add(new Preguntas()
        {
            ID=5,
            IDAlimento = 3,
            IDTipoAlimento = 2,
            Pregunta = "Aunque las llamamos fresas, lo que comemos habitualmente son fresones.",
            Respuesta = true
        });        

        lista.Add(new Preguntas()
        {
            ID=6,
            IDAlimento = 3,
            IDTipoAlimento = 2,
            Pregunta = "La principal provincia productora de fresas y otros frutos rojos es Jaén.",
            Respuesta = false
        });   

        // NO HAY PREGUNTAS DE KIWI

        // PLATANO
        lista.Add(new Preguntas()
        {
            ID=7,
            IDAlimento = 5,
            IDTipoAlimento = 2,
            Pregunta = "En Canarias se producen plátanos de muy buena calidad. Sus manchitas oscuras son características.",
            Respuesta = true
        });        

        lista.Add(new Preguntas()
        {
            ID=8,
            IDAlimento = 5,
            IDTipoAlimento = 2,
            Pregunta = "El plátano es una fruta típica de climas fríos.",
            Respuesta = false
        });        

        // MANDARINA
        lista.Add(new Preguntas()
        {
            ID=9,
            IDAlimento = 6,
            IDTipoAlimento = 2,
            Pregunta = "La mandarina es una fruta de invierno, al igual que la naranja.",
            Respuesta = true
        });        

        lista.Add(new Preguntas()
        {
            ID=10,
            IDAlimento = 6,
            IDTipoAlimento = 2,
            Pregunta = "Las mandarinas clementinas deben su nombre a un cura que las descrubrió en un jardín en Argelia.",
            Respuesta = true
        });                

        // NO HAY PREGUNTAS DE POMELO

        // MANGO
        lista.Add(new Preguntas()
        {
            ID=11,
            IDAlimento = 8,
            IDTipoAlimento = 2,
            Pregunta = "El mango es una fruta típica del norte de Europa. Neceista frío para crecer y dar fruto.",
            Respuesta = false
        });                

        lista.Add(new Preguntas()
        {
            ID=12,
            IDAlimento = 8,
            IDTipoAlimento = 2,
            Pregunta = "Un mango en su punto óptimo de maduración, además de estar riquísimo, nos aporta bastante provitamina A y otras vitaminas y minerales necesarios para cuidar de la salud.",
            Respuesta = true
        });                

        // AGUACATE
        lista.Add(new Preguntas()
        {
            ID=13,
            IDAlimento = 9,
            IDTipoAlimento = 2,
            Pregunta = "El aguacate es prácticamente la única fruta que proporciona grasa monoinsaturada, es decir, sana para nuestro organismo.",
            Respuesta = true
        });                

        lista.Add(new Preguntas()
        {
            ID=14,
            IDAlimento = 9,
            IDTipoAlimento = 2,
            Pregunta = "El principal componente del aguacate es agua, de ahí la primera parte del nombre.",
            Respuesta = false
        });                

        // TOMATE
        lista.Add(new Preguntas()
        {
            ID=15,
            IDAlimento = 10,
            IDTipoAlimento = 3,
            Pregunta = "El tomate cherry es un cruce entre tomate y cereza y se obtiene de un arbusto.",
            Respuesta = false
        });                

        lista.Add(new Preguntas()
        {
            ID=16,
            IDAlimento = 10,
            IDTipoAlimento = 3,
            Pregunta = "El tomate procede de América del Sur, lo trajeron a Europa los conquistadores españoles y durante mucho tiempo se utilizó como planta ornamental.",
            Respuesta = true
        });                

        lista.Add(new Preguntas()
        {
            ID=17,
            IDAlimento = 10,
            IDTipoAlimento = 3,
            Pregunta = "Las siglas del tomate RAF corresponden a 'rojo almeriense fuerte'.",
            Respuesta = false
        });                

        // CEBOLLA
        lista.Add(new Preguntas()
        {
            ID=18,
            IDAlimento = 11,
            IDTipoAlimento = 3,
            Pregunta = "Cuando se corta la cebolla se produce ácido sulfúrico que es lo que nos hace llorar los ojos.",
            Respuesta = true
        });                

        lista.Add(new Preguntas()
        {
            ID=19,
            IDAlimento = 11,
            IDTipoAlimento = 3,
            Pregunta = "La cebolla es un alimento muy rico en azúcares, por lo que hay que comerla con moderación.",
            Respuesta = false
        });                

        // ESPÁRRAGOS
        lista.Add(new Preguntas()
        {
            ID=20,
            IDAlimento = 12,
            IDTipoAlimento = 3,
            Pregunta = "A las raíces de la planta del espárrago se les llama 'garra', aunque no arañen.",
            Respuesta = false
        });                

        lista.Add(new Preguntas()
        {
            ID=21,
            IDAlimento = 12,
            IDTipoAlimento = 3,
            Pregunta = "En la vega de Granada se produce un espárrago muy valorado por su calidad.",
            Respuesta = true
        });                

        // ZANAHORIAS
        lista.Add(new Preguntas()
        {
            ID=22,
            IDAlimento = 13,
            IDTipoAlimento = 3,
            Pregunta = "La comunidad autónoma de Andalucía es la principal porductora de zanahorias en España.",
            Respuesta = true
        });                

        lista.Add(new Preguntas()
        {
            ID=23,
            IDAlimento = 13,
            IDTipoAlimento = 3,
            Pregunta = "Existen zanahorias blancas, amarillas y purpuras.",
            Respuesta = true
        });                

        // PATATA
        lista.Add(new Preguntas()
        {
            ID=24,
            IDAlimento = 14,
            IDTipoAlimento = 1,
            Pregunta = "La patata procede de América, en concreto de la cordillera de los Andes.",
            Respuesta = true
        });                

        lista.Add(new Preguntas()
        {
            ID=25,
            IDAlimento = 14,
            IDTipoAlimento = 1,
            Pregunta = "Existen más de 4000 variedades de patatas en el mundo, de muchos colores y formas. Algunas tienen la carne azul y púrpura.",
            Respuesta = true
        });                

        //---------------------
        // Puesto de lácteos: 8 Preguntas
        //---------------------

        // LECHE
        lista.Add(new Preguntas()
        {
            ID=26,
            IDAlimento = 15,
            IDTipoAlimento = 4,
            Pregunta = "La vaca frisona está especializada en producir leche, es de color blanco y lila claro, y vive en las montañas.",
            Respuesta = false
        });            

        lista.Add(new Preguntas()
        {
            ID=27,
            IDAlimento = 15,
            IDTipoAlimento = 4,
            Pregunta = "La leche es un alimento básico, completo y equilibrado que proporciona un elevado contenido de nutrientes.",
            Respuesta = true
        });            
        
        // MANTEQUILLA
        lista.Add(new Preguntas()
        {
            ID=28,
            IDAlimento = 16,
            IDTipoAlimento = 12,
            Pregunta = "La mantequilla se obtiene al batir la nata que contiene la leche.",
            Respuesta = true
        });            

        lista.Add(new Preguntas()
        {
            ID=29,
            IDAlimento = 16,
            IDTipoAlimento = 12,
            Pregunta = "La mantequilla y margarina son lo mismo, simplemente son dos marcas comerciales.",
            Respuesta = false
        });            

        // QUESO
        lista.Add(new Preguntas()
        {
            ID=30,
            IDAlimento = 17,
            IDTipoAlimento = 4,
            // Pregunta = "En la sierra de Cádiz se produce un queso muy valorado con la leche de una cabra de raza autóctona: la cabra Payoya.",
            Pregunta = "Algunos de los quesos más valorados en Andalucía se elaboran con leche de una cabra autóctona: la cabra malagueña.",
            Respuesta = true
        });            

        lista.Add(new Preguntas()
        {
            ID=31,
            IDAlimento = 17,
            IDTipoAlimento = 4,
            Pregunta = "Los quesos curados se llaman así porque en su elaboración intervienen bacterias, y claro, luego hay que curarlos.",
            Respuesta = false
        });            

        // YOGUR
        lista.Add(new Preguntas()
        {
            ID=32,
            IDAlimento = 18,
            IDTipoAlimento = 4,
            Pregunta = "Los primeros yogures se descubrieron por casualidad hará unos 5000 años.",
            Respuesta = true
        });            

        lista.Add(new Preguntas()
        {
            ID=33,
            IDAlimento = 18,
            IDTipoAlimento = 4,
            Pregunta = "Los nutrientes del yogur, se asimilan y aprovechan mejor que los de la leche, gracias a la fermentación producida por unas bacterias.",
            Respuesta = true
        });            

        //---------------------
        // Panadería y bollería: 9 preguntas
        //---------------------

        // PAN
        lista.Add(new Preguntas()
        {
            ID=34,
            IDAlimento = 19,
            IDTipoAlimento = 1,
            Pregunta = "Los ingredientes principales del pan son harina, agua, levadura y sal.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=35,
            IDAlimento = 19,
            IDTipoAlimento = 1,
            Pregunta = "El pan nos aporta principalmente proteinas.",
            Respuesta = false
        });

        lista.Add(new Preguntas()
        {
            ID=36,
            IDAlimento = 19,
            IDTipoAlimento = 1,
            Pregunta = "El pan integral tiene menos calorías que el normal.",
            Respuesta = false
        });

        // BIZCOCHO
        lista.Add(new Preguntas()
        {
            ID=37,
            IDAlimento = 20,
            IDTipoAlimento = 1,
            Pregunta = "Mientras sea casero, puedes tomar todo el bizcocho que quieras.",            
            Respuesta = false
        });

        lista.Add(new Preguntas()
        {
            ID=38,
            IDAlimento = 20,
            IDTipoAlimento = 1,
            Pregunta = "El bizcocho se llama así porque originalmente era una masa que se cocía dos veces.",
            Respuesta = true
        });

        // DONUT
        lista.Add(new Preguntas()
        {
            ID=39,
            IDAlimento = 21,
            IDTipoAlimento = 1,
            Pregunta = "Los primeros donuts no tenían agujero en el centro, pero si unos frutos secos en su interior.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=40,
            IDAlimento = 21,
            IDTipoAlimento = 1,
            Pregunta = "Como tienen un agujero en el centro, los donuts son más saludables que otro tipo de bollería, ya que estás comiendo aire.",
            Respuesta = false
        });

        // GALLETAS
        lista.Add(new Preguntas()
        {
            ID=41,
            IDAlimento = 22,
            IDTipoAlimento = 1,
            //Pregunta = "Las galletas maría se crearon a finales del siglo XIX para celebrar la boda de unos príncipes.",
            Pregunta = "Los ingredientes básicos de las galletas son harina, azúcar y mantequilla.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=42,
            IDAlimento = 22,
            IDTipoAlimento = 1,
            Pregunta = "Las galletas son muy sanas porque apenas tienen grasa ni azúcar.",
            Respuesta = false
        });
        
        //---------------------
        // Varios
        //---------------------

        // HUEVO
        lista.Add(new Preguntas()
        {
            ID=43,
            IDAlimento = 23,
            IDTipoAlimento = 7,
            Pregunta = "Una gallina actual pone de 300 a 325 al año, es decir, casi un huevo al día.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=44,
            IDAlimento = 23,
            IDTipoAlimento = 7,
            Pregunta = "Solo los huevos ecológicos tienen un código impreso en su cáscara.",
            Respuesta = false
        });

        // AZÚCAR
        lista.Add(new Preguntas()
        {
            ID=45,
            IDAlimento = 24,
            IDTipoAlimento = 11,
            Pregunta = "El azúcar se elabora a partir de la caña de azúcar o de la remolacha azucarera.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=46,
            IDAlimento = 24,
            IDTipoAlimento = 11,
            Pregunta = "El azúcar es fundamental en repostería, pero cada vez está presente en más alimentos procesados.",
            Respuesta = true
        });

        // ACEITE DE OLIVA
        lista.Add(new Preguntas()
        {
            ID=47,
            IDAlimento = 25,
            IDTipoAlimento = 10,
            Pregunta = "El nombre del aceite proviene del árabe 'Al-zait', que significa 'jugo de aceituna'.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=48,
            IDAlimento = 25,
            IDTipoAlimento = 10,
            Pregunta = "Dentro de los tipos de aceite, el de mejor calidad es el virgen extra.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=49,
            IDAlimento = 25,
            IDTipoAlimento = 10,
            Pregunta = "En España hay más de 260 variedades de olivo. En Andalucía tenemos sobre todo la Picual y la Hojiblanca.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=50,
            IDAlimento = 25,
            IDTipoAlimento = 10,
            Pregunta = "El aceite de palma es la principal fuente de grasa en la dieta mediterránea.",
            Respuesta = false
        });

        // ACEITUNAS
        lista.Add(new Preguntas()
        {
            ID=51,
            IDAlimento = 26,
            IDTipoAlimento = 9,
            Pregunta = "Las aceitunas son el fruto del aceituno.",
            Respuesta = false
        });

        lista.Add(new Preguntas()
        {
            ID=52,
            IDAlimento = 26,
            IDTipoAlimento = 9,
            Pregunta = "La aceituna se cosecha en pleno verano.",
            Respuesta = false
        });

        // ARROZ
        lista.Add(new Preguntas()
        {
            ID=53,
            IDAlimento = 27,
            IDTipoAlimento = 1,
            Pregunta = "En España no se cultiva arroz porque es un cultivo tropical.",
            Respuesta = false
        });

        lista.Add(new Preguntas()
        {
            ID=54,
            IDAlimento = 27,
            IDTipoAlimento = 1,
            Pregunta = "Su grano es muy rico en energía, en forma de carbohidratos.",
            Respuesta = true
        });

        // En Alimento() hay una entrada para "Arroz desayuno", que sé no a qué se debe

        // MAÍZ
        lista.Add(new Preguntas()
        {
            ID=55,
            IDAlimento = 29,
            IDTipoAlimento = 1,
            Pregunta = "Hay distintas variedades de maíz para distintos usos: palomitas, dulce, para pienso de los animales, cereales del desayuno o nachos.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=56,
            IDAlimento = 29,
            IDTipoAlimento = 1,
            Pregunta = "El maíz era un alimento muy importante para los antiguos romanos, incluso tenían su propio dios que se llamaba Panochus.",
            Respuesta = false
        });

        // En Alimento() "maiz" está repetido con un ID diferente y una observacion diferente. No sé a qué se debe

        // GARBANZOS
        lista.Add(new Preguntas()
        {
            ID=57,
            IDAlimento = 31,
            IDTipoAlimento = 8,
            Pregunta = "Los garbanzos son legumbres.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=58,
            IDAlimento = 31,
            IDTipoAlimento = 8,
            Pregunta = "Hace más de 2000 años los chinos ya cultivaban garbanzos.",
            Respuesta = false
        });

        // PASTA
        lista.Add(new Preguntas()
        {
            ID=59,
            IDAlimento = 32,
            IDTipoAlimento = 1,
            Pregunta = "La pasta se elabora a partir de harina de trigo duro.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=60,
            IDAlimento = 32,
            IDTipoAlimento = 1,
            Pregunta = "Un plato de pasta nos aporta principalmente carbohidratos.",
            Respuesta = true
        });

        // HARINA DE TRIGO
        lista.Add(new Preguntas()
        {
            ID=61,
            IDAlimento = 33,
            IDTipoAlimento = 1,
            Pregunta = "La harina de trigo integral es más nutritiva que la refinada.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=62,
            IDAlimento = 33,
            IDTipoAlimento = 1,
            Pregunta = "El trigo se obtiene del árbol triguero, como los espárragos.",
            Respuesta = false
        });

        // ALMENDRAS
        lista.Add(new Preguntas()
        {
            ID=63,
            IDAlimento = 34,
            IDTipoAlimento = 1,
            Pregunta = "La almendra es un fruto seco de origen tropical, ya que el almendro necesita mucha agua para crecer y dar frutos.",
            Respuesta = false
        });

        lista.Add(new Preguntas()
        {
            ID=64,
            IDAlimento = 34,
            IDTipoAlimento = 1,
            //Pregunta = "Las almendras hay que comerlas con moderación porque son frutos secos y engordan mucho.",
            Pregunta = "La almendra es un fruto seco que hay que evitar porque engorda muchísimo.",
            Respuesta = false
        });

        // MIEL
        lista.Add(new Preguntas()
        {
            ID=65,
            IDAlimento = 35,
            IDTipoAlimento = 11,
            Pregunta = "Como la miel la producen las abejas, y por tanto es de origen natural, podemos tomar la que queramos ya que no engorda.",
            Respuesta = false
        });

        lista.Add(new Preguntas()
        {
            ID=66,
            IDAlimento = 35,
            IDTipoAlimento = 11,
            Pregunta = "Andalucía es el principal productor de miel en Europa.",
            Respuesta = true
        });

        // MERMELADA
        lista.Add(new Preguntas()
        {
            ID=67,
            IDAlimento = 36,
            IDTipoAlimento = 2,
            Pregunta = "La palabra mermelada proviene del término portugués 'marmelada', cuyo significado es 'confitura de membrillo'.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=68,
            IDAlimento = 36,
            IDTipoAlimento = 2,
            Pregunta = "Como tiene mucha fruta, la mermelada cuenta como una de las raciones de fruta diaria que tenemos que tomar.",
            Respuesta = false
        });

        // CARNE DE VACA
        lista.Add(new Preguntas()
        {
            ID=69,
            IDAlimento = 37,
            IDTipoAlimento = 5,
            Pregunta = "La carne de vaca nos aporta principalmente proteínas.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=70,
            IDAlimento = 37,
            IDTipoAlimento = 5,
            Pregunta = "Las vacas nos dan leche y los toros nos dan carne.",
            Respuesta = false
        });

        // CARNE DE POLLO
        lista.Add(new Preguntas()
        {
            ID=71,
            IDAlimento = 38,
            IDTipoAlimento = 5,
            Pregunta = "La carne de pollo nos aporta principalmente fibra y hierro.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=72,
            IDAlimento = 38,
            IDTipoAlimento = 5,
            Pregunta = "Los pollos camperos no viven en granjas, viven libres en el campo y los tienen que cazar para comérnoslos.",
            Respuesta = false
        });

        // EMBUTIDO
        lista.Add(new Preguntas()
        {
            ID=73,
            IDAlimento = 39,
            IDTipoAlimento = 5,
            //Pregunta = "Los cerdos pueden ser blancos o ibéricos.",
            Pregunta = "Los cerdos pueden ser de diferentes razas, una de ella es la ibérica.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=74,
            IDAlimento = 39,
            IDTipoAlimento = 5,
            Pregunta = "Un jamón de pata negra se distingue porque es completamente negro.",
            Respuesta = false
        });

        lista.Add(new Preguntas()
        {
            ID=75,
            IDAlimento = 39,
            IDTipoAlimento = 5,
            Pregunta = "El jamón, serrano o ibérico, se obtiene tras salar y secar al aire las patas traseras del cerdo.",
            Respuesta = true
        });

        // ATÚN O CABALLA
        lista.Add(new Preguntas()
        {
            ID=76,
            IDAlimento = 40,
            IDTipoAlimento = 6,
            Pregunta = "Las conservas de pescado aportan varios nutrientes esenciales para nuestro organismo.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=77,
            IDAlimento = 40,
            IDTipoAlimento = 6,
            Pregunta = "Las conservas de pescado es un producto procesado que debemos evitar.",
            Respuesta = false
        });

        lista.Add(new Preguntas()
        {
            ID=78,
            IDAlimento = 40,
            IDTipoAlimento = 6,
            Pregunta = "Una conserva de caballa en aceite tiene muchas proteínas porque es la carne de las hembras de los caballos.",
            Respuesta = false
        });

        //---------------------
        // PREGUNTAS ADICIONALES ANEXO II
        //---------------------

        // FRUTAS Y VERDURAS

        // sandía

        lista.Add(new Preguntas()
        {
            ID=79,
            IDAlimento = 41,
            IDTipoAlimento = 2,
            Pregunta = "La sandía realmente es una hortaliza. De hecho es pariente lejana de la calabaza, el pepino o el melón.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=80,
            IDAlimento = 41,
            IDTipoAlimento = 2,
            Pregunta = "Las sandías que no tienen pepitas es porque se las han quitado una a una.",
            Respuesta = false
        });

        // berries
        
        lista.Add(new Preguntas()
        {
            ID=81,
            IDAlimento = 42,
            IDTipoAlimento = 2,
            Pregunta = "Las berries (fresas, frambuesas, moras y arándanos) aportan diversas sustancias que son unas buenas aliadas a la hora de cuidar tu corazón.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=82,
            IDAlimento = 42,
            IDTipoAlimento = 2,
            Pregunta = "Desde Huelva viajan frutos rojos a todos los países de Europa, que los valoran por su gran calidad.",
            Respuesta = true
        });

        lista.Add(new Preguntas()
        {
            ID=83,
            IDAlimento = 42,
            IDTipoAlimento = 2,
            Pregunta = "Las frambuesas son un tipo muy raro de fresas que se desarrollaron en Francia.",
            Respuesta = false
        });

        return lista;
    }
}
