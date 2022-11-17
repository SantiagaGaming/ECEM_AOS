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
        _wrapper = FindObjectOfType<WebSocketWrapper>();
        _wrapper.OnClientConnected += OnReadyToConnect;
    }
    private void OnReadyToConnect()
    {
        _connectionChecker.OnConnect();
    }
}
