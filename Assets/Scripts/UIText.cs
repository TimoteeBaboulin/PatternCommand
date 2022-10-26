using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour{
    private bool _isFusing;
    private TextMeshProUGUI _tmp;

    private void Awake(){
        _tmp = GetComponent<TextMeshProUGUI>();
        Manager.OnFuseChange += () => {
            _isFusing = !_isFusing;
            _tmp.text = _isFusing == true ? "Fuse" : "Replace";
        };
    }
}
