using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace Crescive.Economics.UI
{
    public class CoinUI : MonoBehaviour
    {
        #region INSPECTOR FIELDS

        [Header("References")]
        [SerializeField] private CoinSystem coinSystem;
        [SerializeField] private IntReference collectedCoins;
        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private Transform coinParent;
        [SerializeField] private Transform coinModelParent;
        [SerializeField] private TextMeshProUGUI coinText;

        [FoldoutGroup("Animation Settings")] [SerializeField] private float coinPunchScale = 1.25f;
        [FoldoutGroup("Animation Settings")] [SerializeField] private float coinPunchDuration = .3f;
        [Space]
        [FoldoutGroup("Animation Settings")] [SerializeField] private Ease moveEase = Ease.Unset;
        [FoldoutGroup("Animation Settings")] [SerializeField] private Vector2 minMaxMoveDuration = new Vector2(.6f, 1.2f);
        [Space]
        [FoldoutGroup("Animation Settings")] [SerializeField] private Ease decreaseMoveEase = Ease.OutExpo;
        [FoldoutGroup("Animation Settings")] [SerializeField] private Vector2 minMaxDecreaseMoveDuration = new Vector2(.3f, 1.2f);
        [Space]
        [FoldoutGroup("Animation Settings")] [SerializeField] private float minPointDistance = 3f;
        [FoldoutGroup("Animation Settings")] [SerializeField] private float maxPointDistance = 6f;
        [Space]
        [FoldoutGroup("Animation Settings")] [SerializeField] private float minRotateAngle = -60f;
        [FoldoutGroup("Animation Settings")] [SerializeField] private float maxRotateAngle = 60f;
        [Space]
        [FoldoutGroup("Animation Settings")] [SerializeField] private float minPointVariation = 2f;
        [FoldoutGroup("Animation Settings")] [SerializeField] private float maxPointVariation = 4f;

        [FoldoutGroup("Events")] [SerializeField] private UnityEvent OnCoinIncreaseCompleted;
        [FoldoutGroup("Events")] [SerializeField] private UnityEvent OnCoinDecreaseCompleted;

        #endregion

        #region PUBLIC PROPERTIES

        public IntReference CollectedCoins => collectedCoins;

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            coinText.text = coinSystem.Coin.ToString();
            collectedCoins.Value = 0;
        }

        private void OnDestroy() => collectedCoins.Value = 0;

        #endregion

        #region PUBLIC METHODS

        public void AnimateCoinWorldPosition(Vector3 coinWorldPosition) =>
            AnimateCoinAmountWorldPosition(new IntVector3Pair(1, coinWorldPosition));

        public void AnimateCoinCanvasPosition(Vector3 coinCanvasPosition) =>
            AnimateCoinAmountCanvasPosition(new IntVector3Pair(1, coinCanvasPosition));

        public void AnimateCoinAmountWorldPosition(IntVector3Pair amountWorldPos) =>
            AnimateIncreaseCoinCurvedMultiple(amountWorldPos.IntValue, Camera.main.WorldToScreenPoint(amountWorldPos.Vector3Value));

        public void AnimateCoinAmountCanvasPosition(IntVector3Pair amountCanvasPos) =>
            AnimateIncreaseCoinCurvedMultiple(amountCanvasPos.IntValue, amountCanvasPos.Vector3Value);

        public void AnimateDecreaseCoinAmountWorldPosition(IntVector3Pair amountWorldPos) =>
            AnimateDecreaseCoinCurvedMultiple(amountWorldPos.IntValue, Camera.main.WorldToScreenPoint(amountWorldPos.Vector3Value));

        public void AnimateDecreaseCoinAmountCanvasPosition(IntVector3Pair amountCanvasPos) =>
            AnimateDecreaseCoinCurvedMultiple(amountCanvasPos.IntValue, amountCanvasPos.Vector3Value);

        public void IncreaseCoin(int amount = 1)
        {
            coinSystem.IncreaseCoin(amount);
            CollectedCoins.Value += amount;
            UpdateUI();
        }

        public void DecreaseCoin(int amount = 1)
        {
            coinSystem.DecreaseCoin(amount);
            UpdateUI();
        }

        #endregion

        #region PRIVATE METHODS

        private void AnimateIncreaseCoinAmountLinear(int amount, Vector3 pos)
        {
            var coin = Instantiate(coinPrefab, pos, Quaternion.identity);
            var moveDur = Random.Range(minMaxMoveDuration.x, minMaxMoveDuration.y);
            coin.transform.SetParent(coinParent);
            // coin.transform.DOScale(new Vector3(1, 1, 1), scaleDuration);
            coin.transform.DOLocalMove(Vector3.zero, moveDur)
                .SetEase(moveEase)
                .OnComplete(() =>
                {
                    IncreaseCoin(amount);
                    OnCoinIncreaseAnimationCompleted(coin);
                });
        }

        private void AnimateIncreaseCoinCurvedMultiple(int amount, Vector3 pos)
        {
            for (var i = 0; i < amount; i++)
                AnimateIncreaseCoinCurved(pos);
        }

        private void AnimateIncreaseCoinCurved(Vector3 pos)
        {
            var coin = Instantiate(coinPrefab, pos, Quaternion.identity);
            coin.transform.SetParent(coinParent);
            // coin.transform.DOScale(new Vector3(1, 1, 1), scaleDuration);

            var coinLocalPos = coin.transform.localPosition;
            var coinToCenterDir = (Vector3.zero - coinLocalPos).normalized;
            var pathMidPoint = coinLocalPos + coinToCenterDir * Random.Range(minPointDistance, maxPointDistance);
            var rotatedDir = Quaternion.AngleAxis(Random.Range(minRotateAngle, maxRotateAngle), Vector3.forward) *
                             coinToCenterDir;

            var moveDur = Random.Range(minMaxMoveDuration.x, minMaxMoveDuration.y);

            pathMidPoint += rotatedDir * Random.Range(minPointVariation, maxPointVariation);

            var path = new[]
            {
                pathMidPoint,
                Vector3.zero,
            };

            coin.transform.DOLocalPath(path, moveDur, PathType.CatmullRom)
                .SetEase(moveEase)
                .OnComplete(() =>
                {
                    IncreaseCoin();
                    OnCoinIncreaseAnimationCompleted(coin);
                });
        }

        private void AnimateDecreaseCoinLinearMultiple(int amount, Vector3 pos)
        {
            for (var i = 0; i < amount; i++)
                AnimateDecreaseCoinLinear(pos);
        }

        private void AnimateDecreaseCoinLinear(Vector3 pos)
        {
            var coin = Instantiate(coinPrefab, coinParent.position, Quaternion.identity);
            var moveDur = Random.Range(minMaxDecreaseMoveDuration.x, minMaxDecreaseMoveDuration.y);

            coin.transform.SetParent(coinParent);
            // coin.transform.DOScale(new Vector3(1, 1, 1), scaleDuration);

            DecreaseCoin();
            coin.transform.DOMove(pos, moveDur)
                .SetEase(decreaseMoveEase)
                .OnComplete(() => { OnCoinDecreaseAnimationCompleted(coin); });
        }

        private void AnimateDecreaseCoinCurvedMultiple(int amount, Vector3 pos)
        {
            for (var i = 0; i < amount; i++)
                AnimateDecreaseCoinCurved(pos);
        }

        private void AnimateDecreaseCoinCurved(Vector3 pos)
        {
            var coin = Instantiate(coinPrefab, coinParent.position, Quaternion.identity);
            coin.transform.SetParent(coinParent);
            // coin.transform.DOScale(new Vector3(1, 1, 1), scaleDuration);

            var coinPos = coin.transform.position;
            var coinToCenterDir = (coinPos - pos).normalized;
            var pathMidPoint = coinPos + coinToCenterDir * Random.Range(minPointDistance, maxPointDistance);
            var rotatedDir = Quaternion.AngleAxis(Random.Range(minRotateAngle, maxRotateAngle), Vector3.forward) *
                             coinToCenterDir;

            var moveDur = Random.Range(minMaxDecreaseMoveDuration.x, minMaxDecreaseMoveDuration.y);

            pathMidPoint += rotatedDir * Random.Range(minPointVariation, maxPointVariation);

            var path = new[]
            {
                pathMidPoint,
                pos,
            };

            DecreaseCoin();
            coin.transform.DOPath(path, moveDur, PathType.CatmullRom)
                .SetEase(decreaseMoveEase)
                .OnComplete(() => { OnCoinDecreaseAnimationCompleted(coin); });
        }

        private void UpdateUI()
        {
            coinText.text = coinSystem.Coin.ToString();
            AnimateCoinImage();
        }

        private void AnimateCoinImage()
        {
            coinModelParent.DOKill(true);
            coinModelParent.transform.localScale = Vector3.one;
            coinModelParent.DOPunchScale(Vector3.one * coinPunchScale, coinPunchDuration);
        }

        private void OnCoinIncreaseAnimationCompleted(GameObject coin)
        {
            OnCoinIncreaseCompleted?.Invoke();
            Destroy(coin);
        }

        private void OnCoinDecreaseAnimationCompleted(GameObject coin)
        {
            OnCoinDecreaseCompleted?.Invoke();
            Destroy(coin);
        }

        #endregion
    }
}