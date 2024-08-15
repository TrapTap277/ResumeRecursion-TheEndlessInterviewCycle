using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public class InputReader : MonoBehaviour
    {
        private PlayerInput _playerInput;

        private MoveCommand _moveCommand;
        private JumpCommand _jumpCommand;
        private AttackCommand _attackCommand;
        private CameraCommand _cameraCommand;

        private IJump _jumpBehaviour;
        [Inject(Id = "Shifting")] private IMove _shiftingBehaviour;
        [Inject(Id = "Move")] private IMove _walkBehaviour;
        [Inject(Id = "Run")] private IMove _runBehaviour;
        [Inject(Id = "Camera")] private IMove _cameraBehaviour;
        private IAttack _attackBehaviour;

        private bool _isShifting;
        private bool _isMoving;
        private bool _isRunning;
        private bool _cameraLook;

        private Vector2 _cameraDirection;
        private Vector2 _moveDirection;

        [Inject]
        private void Construct(IJump jump, [Inject(Id = "Shifting")] IMove shiftingPlayer,
            [Inject(Id = "Move")] IMove movePlayer, [Inject(Id = "Run")] IMove runPlayer,
            [Inject(Id = "Camera")] IMove moveCamera, IAttack attack)
        {
            _attackBehaviour = attack;
            _cameraBehaviour = moveCamera;
            _shiftingBehaviour = shiftingPlayer;
            _walkBehaviour = movePlayer;
            _runBehaviour = runPlayer;
            _jumpBehaviour = jump;

            _playerInput = new PlayerInput();

            _moveCommand = new MoveCommand();
            _jumpCommand = new JumpCommand();
            _attackCommand = new AttackCommand();
            _cameraCommand = new CameraCommand();
        }

        private void Start()
        {
            _playerInput.Main.Move.performed += context => ChangeIsMoving(true, context.ReadValue<Vector2>());
            _playerInput.Main.Move.canceled += context => ChangeIsMoving(false, Vector2.zero);
            _playerInput.Main.Shifting.performed += context => SetShifting(true);
            _playerInput.Main.Shifting.canceled += context => SetShifting(false);
            _playerInput.Main.Run.performed += context => SetRun(true);
            _playerInput.Main.Run.canceled += context => SetRun(false);
            _playerInput.Main.Look.performed += context => ChangeCameraLook(true, context.ReadValue<Vector2>());
            _playerInput.Main.Look.canceled += context => ChangeCameraLook(false, Vector2.zero);
            _playerInput.Main.Jump.performed += context => ExecuteJump();
            _playerInput.Main.Attack.performed += context => ExecuteAttack();
        }

        private void SetShifting(bool shiftingState)
        {
            if(_isRunning) return;
            _isShifting = shiftingState;
        }

        private void SetRun(bool runState)
        {
            if(_isShifting) return;
            _isRunning = runState;
        }

        private void ChangeIsMoving(bool isMove, Vector2 direction)
        {
            _isMoving = isMove;
            _moveDirection = direction;
        }

        private void ChangeCameraLook(bool cameraLook, Vector2 direction)
        {
            _cameraLook = cameraLook;
            _cameraDirection = direction;
        }

        private void Update()
        {
            if (_isMoving && _isRunning == false && _isShifting == false) ExecuteMove(_walkBehaviour);
            if (_isMoving && _isShifting) ExecuteMove(_shiftingBehaviour);
            if (_isMoving && _isRunning) ExecuteMove(_runBehaviour);

            if (_cameraLook) ExecuteCameraLook();
        }

        private void ExecuteAttack()
        {
            _attackCommand.Execute(_attackBehaviour);
        }

        private void ExecuteCameraLook()
        {
            _cameraCommand.Execute(_cameraBehaviour, _cameraDirection);
        }

        private void ExecuteJump()
        {
            _jumpCommand.Execute(_jumpBehaviour);
        }

        private void ExecuteMove(IMove move)
        {
            _moveCommand.Execute(move, _moveDirection);
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }
    }
}