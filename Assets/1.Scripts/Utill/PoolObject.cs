using UnityEngine;

public class PoolObject : MonoBehaviour
{
    // PoolObject�� ��ӹ޴� �ڽ� Ŭ������ �ٿ� ĳ����
    public T ReturnMyComponent<T>() where T : PoolObject
    {
        return this as T;
    }
}