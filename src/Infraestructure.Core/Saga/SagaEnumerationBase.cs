namespace Infraestructure.Core.Saga
{
    public class SagaEnumerationBase : Enumeration
    {
        public static SagaEnumerationBase Compleeted = new SagaEnumerationBase(1, "Finished");

        protected SagaEnumerationBase()
        {
        }

        public SagaEnumerationBase(int id, string nome) : base(id, nome)
        {
        }
    }
}