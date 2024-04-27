using Avilesa;
using Avilesa.Model;
using System.CodeDom;

//Para realizar estos test se copiaron los ficheros CSV al proyecto de Test, sino al intentar leer los csv daba error. Se puede ver en uno de los test.

namespace AvilesaTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Se espera que al buscar el municipio con c�digo 33070 devuelva un municipio con ese mismo c�digo
        [Test]
        public void findMunicipio()
        {
            int codMunicipio = 33070;
            LogicaNegocio.readMunicipios();
            Municipio municipio = LogicaNegocio.findMunicipioByCod(codMunicipio);
            Assert.That(municipio.codigoMunicipio, Is.EqualTo(codMunicipio));
        }

        //Se espera que al buscar la l�nea 3628 el resultado sea nulo, la l�nea no existe
        [Test]
        public void findParadaByLinea()
        {
            int numLinea = 3628;
            LogicaNegocio.readParadas();
            Parada parada = LogicaNegocio.findParadaByLinea(numLinea);
            Assert.IsNull(parada);
        }

        //Se esepera que al leer del fichero Lineas.csv de un error, el fichero no existe (No es un caso real pero sirve para ver que el test funciona)
        [Test]
        public void readLineas()
        {
            TestDelegate testDelegate = () => LogicaNegocio.readLineas();
            Assert.Throws<FileNotFoundException>(testDelegate);
            
        }

        //Se espera que al a�adir una l�nea a la lista lstLineas y eliminar esa l�nea usando el m�todo 'removeLinea', esa lista no contenga esa l�nea
        [Test]
        public void removeLinea()
        {
            Linea linea = new Linea(1, 33070, 33080, TimeSpan.Parse("13:00"), TimeSpan.Parse("15:00"));
            LogicaNegocio.lstLineas.Add(linea);
            LogicaNegocio.removeLinea(linea);
            Assert.IsFalse(LogicaNegocio.lstLineas.Contains(linea));
        }

    }
}