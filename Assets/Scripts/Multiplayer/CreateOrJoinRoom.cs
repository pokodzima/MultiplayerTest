using Fusion;
using UnityEngine;
using UnityEngine.UI;

namespace Multiplayer
{
    public class CreateOrJoinRoom : MonoBehaviour
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
                SceneManager = _runner.gameObject.AddComponent<NetworkSceneManagerDefault>()
            });

            _runner.SetActiveScene(_gameScene);
        }
    }

}