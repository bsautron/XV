using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EditorObject : MonoBehaviour {

	private	CanvasGroup	_editorObjectPanel;
	private	CanvasGroup	_editorColorPickerPanel;
	private CanvasGroup	_editorConfirmDeletePanel;
	private	InputField	_editorNameInputField;
	private	InputField	_editorDescriptionInputField;
	private	Text 		_editorMessageText;
	private	Sprite		_editorColorPickerImage;
	private Color[] 	_colorData;

	private	AObject 	_aObj;

	// Color picker
	private	bool		_isOpenColorPicker;
	private int 		_selectRenderer;
	private int 		_selectMaterial;
	private	bool 		_colorPickerLoadValue;
	private InputField	_editorColorRInputField;
	private InputField	_editorColorGInputField;
	private InputField	_editorColorBInputField;
	private Slider		_editorColorRSlider;
	private Slider		_editorColorGSlider;
	private Slider		_editorColorBSlider;
	private Slider 		_editorColorASlider;
	private	Image 		_editorColorResultImage;
	private Dropdown	_editorColorRendererDropdown;
	private Dropdown	_editorColorMaterialDropdown;

	// Transform
	private GameObject	_ground; // Changer en terrain
	private bool		_isTransformPosition;
	private bool 		_isTransformRotation;
	private bool 		_isTransformScale;
	private Text 		_editorTransformText;
	private float 		_mouseX;
	private float		_mouseY;
	private float 		_mousePositionRate = 10f; // < 10 = trés rapide / 10 = rapide / 50 = moyen / + 100 = Lent
	private float		_mouseRotationRate = 50f;
	private float 		_mouseScaleRate = 50f;
	private float		_scaleMin = 0.2f;
	private float 		_scaleMax = 2f;


	void Awake () {
		this._editorObjectPanel = GameObject.Find ("EditorObjectPanel").GetComponent<CanvasGroup> ();
		this._editorColorPickerPanel = GameObject.Find ("EditorColorPickerPanel").GetComponent<CanvasGroup> ();
		this._editorConfirmDeletePanel = GameObject.Find ("EditorConfirmDeletePanel").GetComponent<CanvasGroup> ();
		this._editorNameInputField = GameObject.Find ("EditorNameInputField").GetComponent<InputField> ();
		this._editorDescriptionInputField = GameObject.Find ("EditorDescriptionInputField").GetComponent<InputField> ();
		this._editorMessageText = GameObject.Find ("EditorMessageText").GetComponent<Text> ();
		this._editorColorPickerImage = GameObject.Find ("EditorColorPickerImage").GetComponent<Image>().sprite;
		this._colorData = this._editorColorPickerImage.texture.GetPixels ();

		// Transform
		this._ground = GameObject.Find("Ground");
		this._editorTransformText = GameObject.Find ("EditorTransformText").GetComponent<Text> ();

		// Color picker
		this._editorColorRInputField = GameObject.Find("EditorColorRInputField").GetComponent<InputField>();
		this._editorColorGInputField = GameObject.Find("EditorColorGInputField").GetComponent<InputField>();
		this._editorColorBInputField = GameObject.Find("EditorColorBInputField").GetComponent<InputField>();

		this._editorColorRSlider = GameObject.Find ("EditorColorRSlider").GetComponent<Slider> ();
		this._editorColorGSlider = GameObject.Find ("EditorColorGSlider").GetComponent<Slider> ();
		this._editorColorBSlider = GameObject.Find ("EditorColorBSlider").GetComponent<Slider> ();
		this._editorColorASlider = GameObject.Find ("EditorColorASlider").GetComponent<Slider> ();

		this._editorColorResultImage = GameObject.Find ("EditorColorResultImage").GetComponent<Image> ();

		this._editorColorRendererDropdown = GameObject.Find ("EditorColorRendererDropdown").GetComponent<Dropdown> ();
		this._editorColorMaterialDropdown = GameObject.Find ("EditorColorMaterialDropdown").GetComponent<Dropdown> ();

		this._aObj = null;
	}

	void Update () {
		if (this._isTransformPosition) {
			if (Input.GetKey (KeyCode.X)) {
				UpdateTransformPosition ("x");
			} else if (Input.GetKey (KeyCode.Z)) {
				UpdateTransformPosition ("z");
			}
		} else if (this._isTransformRotation) {
			UpdateTransformRotation ();
		} else if (this._isTransformScale) {
			UpdateTransformScale ();
		}
	}

	public void Init (AObject aObj) {
		this._aObj = aObj;
		this.CloseDelete ();
		this._isOpenColorPicker = false;
		Debug.Log (this._aObj.infos);
		this._editorNameInputField.text = this._aObj.infos.fields["displayName"] as String;
		this._editorDescriptionInputField.text = this._aObj.infos.fields["description"] as String;
		this._editorMessageText.text = "";
		this.ActiveEditorTransform(0);
		this._editorTransformText.text = "";
		this._mouseX = 0;
		this._mouseY = 0;
	}

	public void OpenColorPicker () {
		if (this._isOpenColorPicker) {
			this._isOpenColorPicker = false;
			this._editorColorPickerPanel.alpha = 0;
			this._editorColorPickerPanel.blocksRaycasts = false;
			this._editorColorRendererDropdown.options.Clear ();
			this._editorColorMaterialDropdown.options.Clear ();
		} else {
			this._isOpenColorPicker = true;
			this.InitColorPicker ();
			this._editorColorPickerPanel.alpha = 1;
			this._editorColorPickerPanel.blocksRaycasts = true;
		}
	}

	public void OnMouseOverColorPicker () {
		Vector3 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		screenPos = new Vector2(screenPos.x, screenPos.y);
		Debug.Log (screenPos.y);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		int width = this._editorColorPickerImage.texture.width;
		int height = this._editorColorPickerImage.texture.height;
		Color color;
		if (Physics.Raycast (ray, out hit, 1000)) {
			screenPos -= hit.collider.gameObject.transform.position;
			int x = (int)(screenPos.x * width);
			int y = (int)(screenPos.y * height) + height;
		
			if (x > 0 && x < width && y > 0 && y < height) {
				color = this._colorData [y * width + x];
				Debug.Log (color.r);
			}
		}
	}

	public void UpdateInputFieldColorPicker () {
		if (!this._colorPickerLoadValue) {
			this._editorColorRInputField.text = ((int)this._editorColorRSlider.value).ToString ();
			this._editorColorGInputField.text = ((int)this._editorColorGSlider.value).ToString ();
			this._editorColorBInputField.text = ((int)this._editorColorBSlider.value).ToString ();
			this._editorColorResultImage.color = new Color32 ((byte)this._editorColorRSlider.value, (byte)this._editorColorGSlider.value, (byte)this._editorColorBSlider.value, (byte)this._editorColorASlider.value);
			this._aObj.renderers [this._selectRenderer].materials [this._selectMaterial].color = new Color32 ((byte)this._editorColorRSlider.value, (byte)this._editorColorGSlider.value, (byte)this._editorColorBSlider.value, (byte)this._editorColorASlider.value);
		}
	}

	public void UpdateSliderColorPicker () {
		if (!this._colorPickerLoadValue) {
			try {
				this._editorColorRSlider.value = float.Parse (this._editorColorRInputField.text);
				this._editorColorGSlider.value = float.Parse (this._editorColorGInputField.text);
				this._editorColorBSlider.value = float.Parse (this._editorColorBInputField.text);
				this._editorColorResultImage.color = new Color32 ((byte)this._editorColorRSlider.value, (byte)this._editorColorGSlider.value, (byte)this._editorColorBSlider.value, (byte)this._editorColorASlider.value);
				this._aObj.renderers [this._selectRenderer].materials [this._selectMaterial].color = new Color32 ((byte)this._editorColorRSlider.value, (byte)this._editorColorGSlider.value, (byte)this._editorColorBSlider.value, (byte)this._editorColorASlider.value);
			} catch (FormatException) {
				return;
			}
		}
	}

	public void ChangeRenderer () {
		this._selectMaterial = 0;
		this._selectRenderer = this._editorColorRendererDropdown.value;
		this._editorColorMaterialDropdown.options.Clear ();
		List<String> strListMaterial = new List<String>();
		foreach (Material material in this._aObj.renderers[this._selectRenderer].materials) {
			strListMaterial.Add (material.name);
			this._editorColorMaterialDropdown.options.Add (new Dropdown.OptionData() {text=material.name});
	}
		this.UpdateColorPickerValue ();
	}

	public void ChangeMaterial () {
		this._selectMaterial = this._editorColorMaterialDropdown.value;
		this.UpdateColorPickerValue ();
	}

	public void ActiveEditorTransform (int type) {
		this._isTransformPosition = false;
		this._isTransformRotation = false;
		this._isTransformScale = false;
		switch (type) {
		case 1:
			this._isTransformPosition = true;
			this._editorTransformText.text = "Position\nCommande: (Enfoncé touche(x ou z) + click gauche)";
			break;
		case 2:
			this._isTransformRotation = true;
			this._editorTransformText.text = "Rotation\nCommande: (Enfoncé click gauche)";
			break;
		case 3:
			this._isTransformScale = true;
			this._editorTransformText.text = "Scale\nCommande: (Enfoncé click gauche)";
			break;
		}
	}

	public void Revert () {
		this._editorNameInputField.text = this._aObj.infos.fields ["displayName"] as String;
		this._editorDescriptionInputField.text = this._aObj.infos.fields["description"] as String;
		this._editorMessageText.text = "Annulation des changements";
	}

	public void Validate () {
		this._aObj.infos.UpdateField ("displayName", this._editorNameInputField.text);
		this._aObj.infos.UpdateField ("description", this._editorDescriptionInputField.text);
		this._editorMessageText.text = "Changement réussi";
	}

	public void Delete () {
		this._editorConfirmDeletePanel.alpha = 1;
		this._editorConfirmDeletePanel.blocksRaycasts = true;
	}

	public void ValidateDelete () {
		if (this._aObj && this._aObj.gameObject) {
			Destroy (this._aObj.gameObject);
		}
		this.Close ();
	}

	public void CloseDelete () {
		this._editorConfirmDeletePanel.alpha = 0;
		this._editorConfirmDeletePanel.blocksRaycasts = false;
	}

	public void Open () {
		this._editorObjectPanel.alpha = 1;
		this._editorObjectPanel.blocksRaycasts = true;
	}

	public void Close () {
		this._editorColorPickerPanel.alpha = 0;
		this._editorColorPickerPanel.blocksRaycasts = false;
		this._editorObjectPanel.alpha = 0;
		this._editorObjectPanel.blocksRaycasts = false;
		this._editorColorRendererDropdown.options.Clear ();
		this._editorColorMaterialDropdown.options.Clear ();

		this.SendMessageUpwards ("OpenEditor");
	}

	private void InitColorPicker () {
		this._selectRenderer = 0;
		this._selectMaterial = 0;
		this.UpdateColorPickerValue ();
		List<String> strListRenderer = new List<String>();
		foreach (Renderer renderer in this._aObj.renderers) {
			strListRenderer.Add (renderer.gameObject.name);
			this._editorColorRendererDropdown.options.Add (new Dropdown.OptionData() {text=renderer.gameObject.name});
		}
		if (strListRenderer.Count > 0) {
			List<String> strListMaterial = new List<String>();
			foreach (Material material in this._aObj.renderers[this._selectRenderer].materials) {
				strListMaterial.Add (material.name);
				this._editorColorMaterialDropdown.options.Add (new Dropdown.OptionData() {text=material.name});
			}
		}
		this._editorColorRendererDropdown.value = 0;
		this._editorColorMaterialDropdown.value = 0;
		this._editorColorResultImage.color = new Color32 ((byte)this._aObj.renderers[this._selectRenderer].materials[this._selectMaterial].color.r, (byte)this._aObj.renderers[this._selectRenderer].materials[this._selectMaterial].color.g, (byte)this._aObj.renderers[this._selectRenderer].materials[this._selectMaterial].color.b, (byte)this._aObj.renderers[this._selectRenderer].materials[this._selectMaterial].color.a);
	}

	private void UpdateColorPickerValue () {
		this._colorPickerLoadValue = true;
		this._editorColorRSlider.value = (this._aObj.renderers[this._selectRenderer].materials[this._selectMaterial].color.r * 255.0f);
		this._editorColorRInputField.text = ((int)(this._aObj.renderers[this._selectRenderer].materials[this._selectMaterial].color.r * 255.0f)).ToString();
		this._editorColorGSlider.value = (this._aObj.renderers[this._selectRenderer].materials[this._selectMaterial].color.g * 255.0f);
		this._editorColorGInputField.text = ((int)(this._aObj.renderers[this._selectRenderer].materials[this._selectMaterial].color.g * 255.0f)).ToString();
		this._editorColorBSlider.value = (this._aObj.renderers[this._selectRenderer].materials[this._selectMaterial].color.b * 255.0f);
		this._editorColorBInputField.text = ((int)(this._aObj.renderers[this._selectRenderer].materials[this._selectMaterial].color.b * 255.0f)).ToString();
		this._editorColorASlider.value = (this._aObj.renderers[this._selectRenderer].materials[this._selectMaterial].color.a * 255.0f);
		this._colorPickerLoadValue = false;
	}

	private void UpdateTransformPosition (string vector) {
		GameObject go = this._aObj.gameObject;
		float minx = -this._ground.transform.localScale.x / 2 - (-go.GetComponent<Collider>().bounds.size.x);
		float maxx = this._ground.transform.localScale.x / 2;
		float minz = -this._ground.transform.localScale.z / 2 - (-go.GetComponent<Collider>().bounds.size.z);
		float maxz = this._ground.transform.localScale.z / 2;
		if (Input.GetMouseButtonDown (0)) {
			this._mouseX = Input.mousePosition.x;
			this._mouseY = Input.mousePosition.z;
		}
		if (Input.GetMouseButton (0) && vector == "x") {
			if (Input.mousePosition.x < this._mouseX - this._mousePositionRate) {
				go.transform.Translate (new Vector3 (-0.2f, 0, 0));
				this._mouseX = Input.mousePosition.x;
			} else if (Input.mousePosition.x > this._mouseX + this._mousePositionRate) {
				go.transform.Translate (new Vector3 (0.2f, 0, 0));
				this._mouseX = Input.mousePosition.x;
			}
		} else if (Input.GetMouseButton (0) && vector == "z") {
			if (Input.mousePosition.y < this._mouseY - this._mousePositionRate) {
				go.transform.Translate (new Vector3 (0, 0, -0.2f));
				this._mouseY = Input.mousePosition.y;
			} else if (Input.mousePosition.y > this._mouseY + this._mousePositionRate) {
				go.transform.Translate (new Vector3 (0, 0, 0.2f));
				this._mouseY = Input.mousePosition.y;
			}
		}
		Vector3 v3 = go.transform.position;
		v3.x = Mathf.Clamp (v3.x, minx, maxx);
		v3.z = Mathf.Clamp (v3.z, minz, maxz);
		go.transform.position = v3;
	}

	private void UpdateTransformRotation () {
		GameObject go = this._aObj.gameObject;
		if (Input.GetMouseButtonDown (0)) {
			this._mouseX = Input.mousePosition.x;
		}
		if (Input.GetMouseButton (0)) {
			if (Input.mousePosition.x < this._mouseX - this._mouseRotationRate) {
				Vector3 center = go.GetComponent<Collider> ().bounds.center;
				go.transform.GetChild(0).RotateAround(center, Vector3.down, 90);
				this._mouseX = Input.mousePosition.x;
			} else if (Input.mousePosition.x > this._mouseX + this._mouseRotationRate) {
				Vector3 center = go.GetComponent<Collider> ().bounds.center;
				go.transform.GetChild(0).RotateAround(center, Vector3.up, 90);
				this._mouseX = Input.mousePosition.x;
			}
		}
	}

	// Améliorer le scale min et max;
	private void UpdateTransformScale () {
		GameObject go = this._aObj.gameObject;
		if (Input.GetMouseButtonDown (0)) {
			this._mouseX = Input.mousePosition.x;
		}
		if (Input.GetMouseButton (0)) {
			if (Input.mousePosition.x < this._mouseX - this._mouseScaleRate && go.transform.localScale.x - 0.2f > this._scaleMin) {
				go.transform.localScale -= new Vector3 (0.2f, 0.2f, 0.2f);
				this._mouseX = Input.mousePosition.x;
			} else if (Input.mousePosition.x > this._mouseX + this._mouseScaleRate && go.transform.localScale.x + 0.2 <= this._scaleMax) {
				go.transform.localScale += new Vector3 (0.2f, 0.2f, 0.2f);
				this._mouseX = Input.mousePosition.x;
			}
		}
	}
}