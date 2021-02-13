public class Singleton<T> where T: new()
{
    static protected T m_instance;

    static public T GetInstance()
    {
        if(m_instance == null)
        {
            m_instance = new T();
        }

        return m_instance;
    }

    public virtual void Initialize()
    {

    }
}