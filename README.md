1. Desarrollar un programa donde se observe claramente el uso de los miembros de base en un entorno de herencia. Enfatice las particularidades al usarlo en los constructores y finalizadores. Demuestre en el mismo programa el uso de this. Establezca las diferencias y en qué caso se justifica utilizar cada uno.

Explicación

base: se usa para llamar miembros de la clase padre (constructores, métodos). Ejemplo: : base(nombre) o base.Mostrar().

Pregunta a CHATGPT: Consulta, como es que base sabe a que metodo llamo? Por ejmplo en el codigo puedo tener mas de una funcion Mostrar(): using System;
RESPUESTA

```
La clave está en cómo funciona resolución de métodos en C# con herencia, sobrecarga y sobrescritura.

🔹 1. ¿Qué hace base.Mostrar()?

Cuando escribís:

base.Mostrar();


lo que ocurre es:

base no significa "ir a buscar cualquier método Mostrar de la jerarquía",
sino "invocar la implementación inmediata en la clase base de este método en particular".

El compilador sabe que Estudiante sobrescribe (override) un método llamado Mostrar definido en Persona.

Entonces, base.Mostrar() apunta directamente a la versión que está en Persona.

En otras palabras: si hay varios Mostrar sobrecargados en la clase base, base usa las mismas reglas de sobrecarga que this. Se selecciona la que mejor coincide con los parámetros que le pasaste.

🔹 2. Caso con sobrecarga

Si tuvieras esto en la clase base:

public virtual void Mostrar()
{
    Console.WriteLine($"Persona: {Nombre}");
}

public void Mostrar(string prefijo)
{
    Console.WriteLine($"{prefijo} {Nombre}");
}


En la clase derivada podrías hacer:

public override void Mostrar()
{
    base.Mostrar();           // Llama al virtual Persona.Mostrar()
    base.Mostrar("Alumno:");  // Llama a la sobrecarga Persona.Mostrar(string)
    Console.WriteLine($"Edad: {Edad}");
}


➡️ El compilador sabe cuál llamar porque distingue por firma del método (nombre + parámetros).

🔹 3. Diferencia con this

this.Mostrar() → llama al método actual, que puede ser el sobrescrito en la clase hija.

base.Mostrar() → llama al método de la clase base (saltándose la sobrescritura).

Ejemplo:

public override void Mostrar()
{
    this.Mostrar();  // ⚠️ ¡Esto sería recursivo infinito, porque llama a sí mismo!
    base.Mostrar();  // ✅ Llama al de Persona
}


✅ Entonces:

base no es mágico, simplemente apunta al método correspondiente en la clase base inmediata.

Si hay varias versiones (overloads), el compilador decide cuál en tiempo de compilación según los parámetros.

override + base es el patrón típico para extender la lógica del padre sin reescribirla toda.
```

this: se refiere al objeto actual, sirve para distinguir propiedades/variables o pasarse como referencia. Ejemplo: this.Edad.

Constructores y finalizadores: se ejecutan en orden jerárquico:

Al crear: primero constructor base, luego constructor hijo.

Al destruir: primero finalizador hijo, luego finalizador base.

### Salida:
<img width="350" height="217" alt="image" src="https://github.com/user-attachments/assets/d0021abd-71f5-4646-8385-b01fcd262708" />


### Codigo y vinculaciones con la salida
<img width="1731" height="823" alt="image" src="https://github.com/user-attachments/assets/7ddce9c9-f56f-4a9d-8435-fbd5f0f587fc" />
