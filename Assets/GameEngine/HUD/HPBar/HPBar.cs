using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour, IOnUpdateInterpolation<float>, IOnUpdateInterpolation<Color>
{
    private const string prefabPath = "HUD/HPBar";
    public static HPBar create(GameObject gameObject)
    {
        Object obj = Utils.loadPrefabFromFile(prefabPath);
        GameObject gameObj = (GameObject) GameObject.Instantiate(obj, gameObject.transform);
        HPBar hpBar = gameObj.GetComponent<HPBar>();
        hpBar.Start();
        gameObj.transform.localPosition = hpBar.shift;
        return hpBar;
    }


    [SerializeField]
    private Vector3 shift;

    protected Slider slider;
    protected CanvasGroup canvasGroup;
    private Image fill;

    private FInterp alphaInterp;
    private ColorInterp fillColorInterp;

    private float minHealthAlwaysShow = 0.3f;
    private Coroutine hideWithDelayTask;
    private bool started = false;

    public void Start()
    {
        if (started)
            return;
        this.slider = this.GetComponentInChildren<Slider>();
        this.canvasGroup = this.GetComponentInChildren<CanvasGroup>();
        this.alphaInterp = new FInterp(0.4f, this);
        this.alphaInterp.pause();
        this.fillColorInterp = new ColorInterp(0.2f, this);
        this.fillColorInterp.pause();
        this.fill = Utils.getChildGameObject(this.gameObject.transform, "Fill").GetComponent<Image>();
        started = true;
    }

    public void Update()
    {
        this.alphaInterp.update();
        this.fillColorInterp.update();
    }

    public void setHealth(float health)
    {
        this.slider.value = health;
        checkHealthVisibility();
    }

    public void setMaxHealth(float maxHealth)
    {
        this.slider.maxValue = maxHealth;
    }

    public void setHealthPercentage(float healthPercentage)
    {
        this.slider.value = this.slider.maxValue * healthPercentage/100;
    }

    public void setShift(float x, float y)
    {
        shift.x = x;
        shift.y = y;
        this.gameObject.transform.localPosition = this.shift;
    }

    public void show()
    {
        cancelHideWithDelayTask();
        setVisibility(true);
    }

    public void showForSeconds(float time)
    {
        setVisibility(true);
        hideWithDelay(time);
    }

    public void hide()
    {
        cancelHideWithDelayTask();
        setVisibility(false);
    }

    public void hideWithDelay(float delay, bool force = false)
    {
        if (!force)
        {
            if (!canHidehealthBar())
                return;
        }
        cancelHideWithDelayTask();
        this.hideWithDelayTask = StartCoroutine("hideWithDelayRun", delay);
    }

    private void cancelHideWithDelayTask()
    {
        if (hideWithDelayTask != null)
        {
            StopCoroutine(this.hideWithDelayTask);
        }
    }

    private IEnumerator hideWithDelayRun(float delay)
    {
        yield return new WaitForSeconds(delay);
        hide();
    }

    public void setVisibility(bool visibility)
    {
        this.alphaInterp.reset();
        if (visibility)
        {
            this.alphaInterp.setValues(this.canvasGroup.alpha, 1);
        }
        else
        {
            this.alphaInterp.setValues(this.canvasGroup.alpha, 0);
        }
    }

    public void setFillColor(Color color)
    {
        this.fill.color = color;
    }

    public void setTargetFillColor(Color color)
    {
        this.fillColorInterp.reset();
        this.fillColorInterp.setValues(this.fill.color, Color.red);
    }

    public float getHealthPercentage()
    {
        return this.slider.value / this.slider.maxValue;
    }

    public void setMinHealthAlwaysShow(float minHealth)
    {
        this.minHealthAlwaysShow = minHealth;
        checkHealthVisibility();
    }

    private void checkHealthVisibility()
    {
        if(!canHidehealthBar())
        {
            setVisibility(true);
        }
    }

    private bool canHidehealthBar()
    {
        return this.getHealthPercentage() > this.minHealthAlwaysShow;
    }

    public void onUpdateInterpolation(Interpolator<float> interpolator, float currentValue)
    {
        this.canvasGroup.alpha = currentValue;
    }

    public void onUpdateInterpolation(Interpolator<Color> interpolator, Color currentValue)
    {
        this.fill.color = currentValue;
    }
}
