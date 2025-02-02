﻿namespace BlazorBootstrap;

public partial class RibbonTab : BlazorBootstrapComponentBase
{
    #region Methods

    /// <inheritdoc />
    protected override async ValueTask DisposeAsyncCore(bool disposing)
    {
        if (disposing && IsRenderComplete)
        {
            try
            {
                await JSRuntime.InvokeVoidAsync("window.blazorBootstrap.tabs.dispose", Id);
            }
            catch (JSDisconnectedException)
            {
                // do nothing
            }
        }

        await base.DisposeAsyncCore(disposing);
    }

    protected override void OnInitialized()
    {
        Id = IdGenerator.GetNextId(); // This is required
        Parent.AddTab(this);
    }

    #endregion

    #region Properties, Indexers

    /// <summary>
    /// Gets or sets the active state.
    /// </summary>
    /// <remarks>
    /// Default value is false.
    /// </remarks>
    [Parameter]
    public bool Active { get; set; }

    /// <summary>
    /// Gets or sets the content to be rendered within the component.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    [EditorRequired]
    public RenderFragment Content { get; set; } = default!;

    /// <summary>
    /// Gets or sets the disabled state.
    /// </summary>
    /// <remarks>
    /// Default value is false.
    /// </remarks>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets the tab name.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public string Name { get; set; } = default!;

    /// <summary>
    /// This event fires when the user clicks the corresponding tab button and the tab is displayed.
    /// </summary>
    [Parameter]
    public EventCallback<TabEventArgs> OnClick { get; set; }

    /// <summary>
    /// Gets or sets the parent ribbon.
    /// </summary>
    [CascadingParameter(Name = "Ribbon1")]
    internal Ribbon Parent { get; set; } = default!;

    /// <summary>
    /// Gets or sets the tab title.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public string Title { get; set; } = default!;

    /// <summary>
    /// Gets or sets the tab title template.
    /// </summary>
    [Parameter]
    public RenderFragment TitleTemplate { get; set; } = default!;

    #endregion
}
