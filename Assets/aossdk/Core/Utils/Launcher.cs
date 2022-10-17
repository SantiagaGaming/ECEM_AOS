using System;
using System.Net;
using UnityEngine;

namespace AosSdk.Core.Utils
{
    [RequireComponent(typeof(WebSocketWrapper))]
    public class Launcher : MonoBehaviour
    {
        [field: SerializeField] public AosSDKSettings SdkSettings { get; private set; }
        [SerializeField] private PlayerModule.Player player;

        private string _webSocketIpAddress = "127.0.0.1";
        private int _webSocketPort = 8080;
        private string _aosPendingSecret = string.Empty;
        
        private WebSocketWrapper _webSocketWrapper;

        private const string AosSecret = "aos";

        internal static Launcher Instance { get; private set; }

        private void Awake()
        {
            Instance ??= this;

            _webSocketWrapper = GetComponent<WebSocketWrapper>();

            var commandLineArguments = Environment.GetCommandLineArgs();

            if (!Application.isEditor)
            {
                foreach (var argument in commandLineArguments)
                {
                    var argumentType = argument.Substring(0, 2);
                    switch (argumentType)
                    {
                        case "-i":
                            _webSocketIpAddress = argument.Substring(2);
                            break;
                        case "-p":
                            _webSocketPort = int.Parse(argument.Substring(2));
                            break;
                        case "-s":
                            _aosPendingSecret = argument.Substring(2);
                            break;
                        case "-m":
                            SdkSettings.launchMode = argument.Substring(2).Contains(LaunchMode.Desktop.ToString()) ? LaunchMode.Desktop : LaunchMode.Vr;
                            break;
                    }
                }
            }
            else
            {
                _webSocketPort = SdkSettings.socketPort;
                _aosPendingSecret = AosSecret;
            }
#if UNITY_STANDALONE_WIN
            if (_aosPendingSecret != AosSecret)
            {
                Debug.LogError("Wrong secret key, quiting...");
                Application.Quit();
            }
#endif
#if UNITY_ANDROID
            sdkSettings.launchMode = LaunchMode.Vr;
#endif
            Debug.Log($"Launched in {SdkSettings.launchMode.ToString()} mode");

            _webSocketWrapper.Init(new IPEndPoint(IPAddress.Parse(_webSocketIpAddress), _webSocketPort));

            player.LaunchMode = SdkSettings.launchMode;
        }
    }
}