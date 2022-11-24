using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionInvoker : MonoBehaviour
{
    private WebSocketWrapper _wrapper;
    [SerializeField] private ConnectionChecker _connectionChecker;

    private void Start()
    {
        StartCoroutine(ConnectionDelay());
    }
    private void OnEnable()
    {
        _wrapper.OnClientConnected += OnReadyToConnect;
    }
    private void OnDisable()
    {
        _wrapper.OnClientConnected -= OnReadyToConnect;
    }
    private void OnReadyToConnect()
    {
        _connectionChecker.OnConnect();
    }
    private IEnumerator ConnectionDelay()
    {
        yield return new WaitForSeconds(1);
        _wrapper = FindObjectOfType<WebSocketWrapper>();
        _wrapper.OnClientConnected += OnReadyToConnect;
    }

}
