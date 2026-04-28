## Detailed Registry Execution Plan

### Storage layout

The registry service should treat `registry.terraform.io` as the first registry root.
Under the configured storage path, the service should expect:

- `registry.terraform.io/plugins/` for provider/plugin artifacts
- `registry.terraform.io/providers/` as a symlink to `plugins/`
- `registry.terraform.io/modules/` for module artifacts

This keeps Terraform protocol compatibility while using a generic `plugins/` implementation folder.

### Abstract behavior

- The service discovers registries under the configured storage root.
- For Terraform, it scans `registry.terraform.io/plugins/` and `registry.terraform.io/modules/`.
- Provider/plugin namespaces and versions are indexed from the filesystem hierarchy.
- Module namespaces and versions are indexed from the filesystem hierarchy.
- The `/v1/providers/...` and `/v1/modules/...` endpoints remain stable for clients.

### Compatibility rules

- Keep the `/providers/` path available through the symlink so existing Terraform clients continue to work.
- Use `plugins/` for the main repository layout to support future registry types.
- Keep module storage under `modules/` adjacent to `plugins/`.

### Testing strategy

- Validate the filesystem layout under `registry/registry.terraform.io/`.
- Verify provider and module indexes are populated from the correct storage paths.
- Verify `/v1/providers/.../versions` and `/v1/modules/.../versions` responses.
- Verify download URLs resolve to storage paths under `/storage/providers/...`.
- Ensure future registry roots can be added with the same pattern.

