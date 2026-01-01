using System;

public abstract class AbstractScreen<TModel> : BaseScreen where TModel : IViewModel
{
    protected TModel _model;
    
    public override Type ModelType => typeof(TModel);

    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public override void Close()
    {
        gameObject.SetActive(false);
    }

    public override void Bind(object model)
    {
        if (model is TModel)
            Bind((TModel)model);
    }

    public void Bind(TModel model)
    {
        _model = model;
        OnBind(model);
    }

    protected abstract void OnBind(TModel model);
}