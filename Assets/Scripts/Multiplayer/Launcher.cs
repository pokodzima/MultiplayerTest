using Fusion;
using UnityEngine;
using UnityEngine.UI;
using Services;
using Multiplayer.ObjectPool;

namespace Multiplayer
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField] private Button _actionButton;
        [SerializeField] private InputField _roomNameField;
        [SerializeField] private string _gameScene;
        private NetworkRunner _runner;

        private void Awake()
        {
            _actionButton.onClick.AddListener(StartGame);
        }

        private async void StartGame()
        {
            _runner = new GameObject("Network Runner").AddComponent<NetworkRunner>();
            _runner.ProvideInput = true;

            await _runner.StartGame(new StartGameArgs()
            {
                GameMode = GameMode.Shared,
                SessionName = _roomNameField.text,
                SceneManager = _runner.gameObject.AddComponent<NetworkSceneManagerDefault>(),
                ObjectPool = _runner.gameObject.AddComponent<FusionObjectPoolRoot>()
            });

            _runner.SetActiveScene(_gameScene);
        }
    }

}